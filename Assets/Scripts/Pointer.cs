using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pointer : MonoBehaviour {
    [SerializeField] private Camera camera;

    private Ray _ray;
    private RaycastHit _hit;

    private static Pointer _instance;

    private float maxDistance = 1;
    private ITank _currentTank;
    [SerializeField] private GameObject _pointerBody;
    private Vector3 _mousePosition = new Vector3();

    private void Awake() {
        if (_instance != null) {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

    private void Update() {
        if (_currentTank == null) return;

        _ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray, out _hit, Mathf.Infinity)) {
            var point = _hit.point;
            _mousePosition = _hit.point;
            _mousePosition.y = 0f;
            if (Vector3.Distance(_hit.point, _currentTank.transform.position) > _currentTank.CurrentFuel) {
                var direction = (_hit.point - _currentTank.transform.position).normalized;
                point = _currentTank.transform.position + direction * _currentTank.CurrentFuel;
            }

            if (NavMesh.SamplePosition(point, out NavMeshHit hit, maxDistance, NavMesh.AllAreas)) {
                transform.position = hit.position;
            }
        }
    }


    public static Vector3 GetMousePosition() => _instance._mousePosition;
    public static Vector3 GetNavMeshPosition() => _instance.transform.position;

    public static void ActivatePointer(ITank tank) {
        _instance._pointerBody.SetActive(true);
        _instance._currentTank = tank;
    }

    public static void DeactivatePointer() {
        _instance._pointerBody.SetActive(false);
        //_instance._currentTank = null;
    }
}