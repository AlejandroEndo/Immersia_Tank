using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private CinemachineTargetGroup _cinemachineTargetGroup;

    private void Awake() {
        TanksManager.Instance.OnTurnChanged += OnTurnChanged;
    }

    private void OnTurnChanged(TankType tankInTurn) {
        _cinemachineTargetGroup.m_Targets[0].weight = tankInTurn == TankType.First ? 1 : 0;
        _cinemachineTargetGroup.m_Targets[1].weight = tankInTurn == TankType.Second ? 1 : 0;
    }
}