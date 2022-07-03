using System;
using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public enum TankType {
    First,
    Second,
}

public class TanksManager : MonoBehaviour {
    public event Action<ITank, ITank> OnTanksCreated;
    public event Action<ITank> OnTurnChanged;

    [SerializeField] private AssetReference tankPlayer;
    [SerializeField] private AssetReference tankIA;

    private ITank _firstTank;
    private ITank _secondTank;

    [FormerlySerializedAs("_spawnPoints")] [SerializeField]
    private SpawnPoint[] spawnPoints;

    public static TanksManager Instance { get; private set; }
    public ITank TankInTurn { get; private set; }

    private NavMeshSurface _navMeshSurface;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        _navMeshSurface = GetComponent<NavMeshSurface>();
        StartCoroutine(LoadTanksAsync());
    }

    private void Start() {
    }

    private IEnumerator LoadTanksAsync() {
        var gameMode = GameStateMachine.Instance.GameMode;

        var firstOperation = gameMode == GameMode.AIVsAI
            ? tankIA.InstantiateAsync()
            : tankPlayer.InstantiateAsync();
        yield return firstOperation;

        var secondOperation = gameMode == GameMode.PlayerVsPlayer
            ? tankPlayer.InstantiateAsync()
            : tankIA.InstantiateAsync();
        yield return secondOperation;

        _firstTank = firstOperation.Result.GetComponent<ITank>();
        _secondTank = secondOperation.Result.GetComponent<ITank>();

        bool randomPos = Random.Range(0f, 1f) >= 0.5f;
        _firstTank.transform.position = spawnPoints[randomPos ? 0 : 1].transform.position;
        _secondTank.transform.position = spawnPoints[randomPos ? 1 : 0].transform.position;

        OnTanksCreated?.Invoke(_firstTank, _secondTank);
        EndTurn();
    }

    public void EndTurn() {
        if (TankInTurn == null || TankInTurn == _secondTank)
            TankInTurn = _firstTank;
        else
            TankInTurn = _secondTank;
        OnTurnChanged?.Invoke(TankInTurn);
    }
}