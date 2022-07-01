using System;
using UnityEngine;

public abstract class UIPanel : MonoBehaviour {
    [SerializeField] protected GameObject panel;
    protected virtual void Start() => GameStateMachine.OnGameStateChanged += OnGameStateChanged;
    protected abstract void OnGameStateChanged(IState state);
    protected virtual void OnDestroy() => GameStateMachine.OnGameStateChanged -= OnGameStateChanged;
}