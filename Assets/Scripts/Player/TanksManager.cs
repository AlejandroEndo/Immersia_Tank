using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public enum TankType {
    First,
    Second,
}

public class TanksManager : MonoBehaviour {
    public event Action<TankType> OnTurnChanged;

    [SerializeField] private TankStateMachine _firstTank;
    [SerializeField] private TankStateMachine _secondTank;

    [SerializeField] private SpawnPoint[] _spawnPoints;

    public static TanksManager Instance { get; private set; }
    public TankType TankInTurn { get; private set; } = TankType.Second;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        bool randomPos = Random.Range(0f, 1f) >= 0.5f;
        _firstTank.transform.position = _spawnPoints[randomPos ? 0 : 1].transform.position;
        _secondTank.transform.position = _spawnPoints[randomPos ? 1 : 0].transform.position;
    }

    private void Start() {
        EndTurn();
    }

    public void EndTurn() {
        TankInTurn = TankInTurn == TankType.First ? TankType.Second : TankType.First;
        OnTurnChanged?.Invoke(TankInTurn);
    }
}