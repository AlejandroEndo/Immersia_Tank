using System;
using UnityEngine;

public class Play : IState {
    private ITank _tankOne;
    private ITank _tankTwo;

    private SpawnPoint[] _spawnPoints;

    public void Tick() {
    }

    public void OnEnter() {
        _spawnPoints = GameObject.FindObjectsOfType<SpawnPoint>();
        CreatePlayers();
    }

    private void CreatePlayers() {
        switch (GameStateMachine.Instance.GameMode) {
            case GameMode.PlayerVsAI:
                break;
            case GameMode.PlayerVsPlayer:
                break;
            case GameMode.AIVsAI:
                break;
        }
    }

    public void OnExit() {
    }
}