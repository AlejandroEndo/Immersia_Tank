using System;
using UnityEngine;

public class Tank : MonoBehaviour, ITank {
    [SerializeField] private Transform tower;
    [SerializeField] private Transform movementRangeDisplay;
    [SerializeField] private float maxFuel = 1f;
    public float MaxFuel => maxFuel;
    public bool HasFuel => CurrentFuel > 0.1f;

    public Transform Target { get; private set; }
    public float CurrentFuel { get; private set; }

    private Vector3 movementRangeScale = new Vector3();

    private void Awake() {
        CurrentFuel = MaxFuel;
    }

    private void Update() {
        if (movementRangeDisplay.gameObject.activeSelf) {
            movementRangeScale = new Vector3(CurrentFuel * 2, 0.1f, CurrentFuel * 2);
            movementRangeDisplay.localScale = movementRangeScale;
        }
    }

    public void RefillFuel() {
        CurrentFuel = maxFuel;
    }

    public void TowerAimRotation(Vector3 direction) {
        tower.rotation = Quaternion.LookRotation(direction);
    }

    public void UseFuel(float amount) {
        CurrentFuel -= amount;
    }

    public void SetMovementRangeDisplay(bool state) {
        movementRangeDisplay.gameObject.SetActive(state);
    }
}