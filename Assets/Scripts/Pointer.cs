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
    private Transform _currentTankTransform;
    [SerializeField] private GameObject _pointerBody;

    private void Awake() {
        if (_instance != null) {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

    private void Update() {
        if (_currentTankTransform == null) return;

        _ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray, out _hit, Mathf.Infinity)) {
            var point = _hit.point;

            if (Vector3.Distance(_hit.point, _currentTankTransform.position) > 7.5f) {
                var direction = (_hit.point - _currentTankTransform.position).normalized;
                point = _currentTankTransform.position + direction * 7.5f;
            }

            if (NavMesh.SamplePosition(point, out NavMeshHit hit, maxDistance, NavMesh.AllAreas)) {
                transform.position = hit.position;
            }
        }
    }

    public static Vector3 GetNavMeshPosition() => _instance.transform.position;

    public static void ActivatePointer(Transform currentTankPosition) {
        _instance._pointerBody.SetActive(true);
        _instance._currentTankTransform = currentTankPosition;
    }

    public static void DeactivatePointer() {
        _instance._pointerBody.SetActive(false);
        _instance._currentTankTransform = null;
    }
}