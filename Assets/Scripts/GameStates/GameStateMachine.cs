using System;
using UnityEngine;

public class GameStateMachine : MonoBehaviour {
    public static event Action<IState> OnGameStateChanged;
    public static GameStateMachine Instance { get; private set; }

    private StateMachine _stateMachine;

    public Type CurrentStateType => _stateMachine.CurrentState.GetType();

    public GameMode GameMode { get; private set; }

    private void Awake() {
        #region SINGLETON

        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        #endregion

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
        //_stateMachine.AddTransition(play, resume, () => Input.GetKeyDown(KeyCode.F));
        _stateMachine.AddTransition(resume, menu, () => UIController.SelectedUIButton == SelectedUIButton.GoToMenu);
    }

    private bool CheckForDifficulty() {
        if (UIPlayButton.SelectedGameMode != GameMode.None) {
            GameMode = UIPlayButton.SelectedGameMode;
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