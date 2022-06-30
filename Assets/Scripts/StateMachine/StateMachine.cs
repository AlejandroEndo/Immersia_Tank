using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine {
    public event Action<IState> OnStateChanged;

    private List<StateTransition> _stateTransitions = new List<StateTransition>();
    private List<StateTransition> _anyStateTransitions = new List<StateTransition>();

    private IState _currentState;
    public IState CurrentState => _currentState;

    public void AddTransition(IState from, IState to, Func<bool> condition) {
        var stateTransition = new StateTransition(from, to, condition);
        _stateTransitions.Add(stateTransition);
    }

    public void AddAnyTransition(IState state, Func<bool> transition) {
        var stateTransition = new StateTransition(null, state, transition);
        _anyStateTransitions.Add(stateTransition);
    }

    public void SetState(IState state) {
        if (_currentState == state) return;

        _currentState?.OnExit();
        _currentState = state;
        Debug.Log($"Changed state to: {state}");
        _currentState.OnEnter();
        OnStateChanged?.Invoke(_currentState);
    }

    public void Tick() {
        var transition = CheckForTransition();

        if (transition != null) {
            SetState(transition.To);
        }

        _currentState.Tick();
    }

    private StateTransition CheckForTransition() {
        foreach (var transition in _anyStateTransitions) {
            if (transition.Condition()) return transition;
        }

        foreach (var transition in _stateTransitions) {
            if (transition.From == _currentState && transition.Condition())
                return transition;
        }

        return null;
    }
}
