using System;
using UnityEngine;

public class Tank : MonoBehaviour, IPlayer {
    [SerializeField] private float maxFuel = 1f;
    public float MaxFuel => maxFuel;
    public bool HasFuel => _fuel > 0;
    public Transform Target { get; private set; }

    private float _fuel;

    private void Awake() {
        _fuel = MaxFuel;
    }

    public void RefillFuel() {
        _fuel = maxFuel;
    }

    public void UseFuel(float amount) {
        _fuel -= amount;
        //Debug.Log($"Remaining Fuel: {_fuel}");
    }
}