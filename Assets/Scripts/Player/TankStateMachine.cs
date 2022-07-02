using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

[RequireComponent(typeof(NavMeshAgent))]
public class TankStateMachine : MonoBehaviour {
    [SerializeField] private TankType tankType;

    private NavMeshAgent _navMeshAgent;
    private Tank _tank;
    private StateMachine _stateMachine;

    private Idle _idle;
    private Moving _moving;
    private Shooting _shooting;

    private bool _isMyTurn;

    private void Awake() {
        _tank = GetComponent<Tank>();
        _navMeshAgent = GetComponent<NavMeshAgent>();

        StateMachineConfig();
        TanksManager.Instance.OnTurnChanged += OnTurnChanged;
    }

    private void StateMachineConfig() {
        _stateMachine = new StateMachine();

        _idle = new Idle(_tank);
        _moving = new Moving(_navMeshAgent, _tank);
        _shooting = new Shooting(_tank);

        _stateMachine.SetState(_idle);

        _stateMachine.AddTransition(_idle, _moving, () => _isMyTurn);
        _stateMachine.AddTransition(_moving, _shooting, () => !_tank.HasFuel);
        _stateMachine.AddTransition(_shooting, _idle, () => false);
    }

    private void OnTurnChanged(TankType tankTurn) {
        _isMyTurn = tankTurn == tankType;
    }

    private void Update() => _stateMachine.Tick();

    private void OnDestroy() => TanksManager.Instance.OnTurnChanged -= OnTurnChanged;
}