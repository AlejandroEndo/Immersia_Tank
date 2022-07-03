using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Tank : MonoBehaviour, ITank {
    [SerializeField] private Transform tower;
    [SerializeField] private Transform barrel;
    [SerializeField] private Transform movementRangeDisplay;
    [SerializeField] private float maxFuel = 1f;
    [SerializeField] private float maxForce;
    [SerializeField] private Bullet bulletPrefab;
    public float MaxFuel => maxFuel;
    public bool HasFuel => CurrentFuel > 0.1f;

    public Transform Target { get; private set; }
    public float CurrentFuel { get; private set; }

    private Vector3 movementRangeScale = new Vector3();

    private float _currentForce;

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

    public void StartShotCharge() {
        barrel.gameObject.SetActive(true);
        StartCoroutine(LoadingShot());
    }

    private void SetBarrelScale(float z) {
        var scale = barrel.localScale;
        scale.z = z;
        barrel.localScale = scale;
    }

    private IEnumerator LoadingShot() {
        while (_currentForce < maxForce) {
            _currentForce += Time.deltaTime;
            SetBarrelScale(_currentForce);
            yield return null;
        }
    }

    public void ReleaseShot() {
        ShotBullet();

        SetBarrelScale(0f);
        _currentForce = 0f;
        barrel.gameObject.SetActive(false);
    }

    private void ShotBullet() {
        var bullet = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        bullet.Shot(_currentForce);
    }
}