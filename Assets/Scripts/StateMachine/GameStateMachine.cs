﻿using System;
using UnityEngine;

public class GameStateMachine : MonoBehaviour {
    public static event Action<IState> OnGameStateChanged;
    private static GameStateMachine _instance;

    private StateMachine _stateMachine;

    public Type CurrentStateType => _stateMachine.CurrentState.GetType();

    public Difficulty Difficulty { get; private set; }

    private void Awake() {
        if (_instance != null) { // Private singleton
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject); // This GameObject manage all the game flow.

        _stateMachine = new StateMachine();

        var menu = new Menu();
        var loading = new Loading();
        var play = new Play();
        var resume = new Resume();
        var pause = new Pause();

        _stateMachine.OnStateChanged += state => OnGameStateChanged?.Invoke(state);
        _stateMachine.SetState(menu);

        _stateMachine.AddTransition(menu, loading, CheckForDifficulty);
        _stateMachine.AddTransition(loading, play, loading.Finish);
        _stateMachine.AddTransition(play, pause, () => Input.GetKeyDown(KeyCode.P));
        _stateMachine.AddTransition(pause, play, UnPauseCheck);
        _stateMachine.AddTransition(pause, menu, () => UIController.SelectedUIButton == SelectedUIButton.GoToMenu);
        _stateMachine.AddTransition(play, resume, () => Input.GetKeyDown(KeyCode.F));
        _stateMachine.AddTransition(resume, menu, () => UIController.SelectedUIButton == SelectedUIButton.GoToMenu);
    }

    private bool CheckForDifficulty() {
        if (UIPlayButton.SelectedDifficulty != Difficulty.None) {
            Difficulty = UIPlayButton.SelectedDifficulty;
            return true;
        }

        return false;
    }

    private bool UnPauseCheck() =>
        UIController.SelectedUIButton == SelectedUIButton.Continue || Input.GetKeyDown(KeyCode.P);

    private void Update() {
        _stateMachine.Tick();
    }
}