using System;
using UnityEngine;

public class Play : IState {
    private IPlayer _playerOne;
    private IPlayer _playerTwo;

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