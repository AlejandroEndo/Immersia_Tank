using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private CinemachineTargetGroup _cinemachineTargetGroup;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    private void Awake() {
        TanksManager.Instance.OnTanksCreated += OnTanksCreated;
        TanksManager.Instance.OnTurnChanged += OnTurnChanged;
    }

    private void OnTurnChanged(ITank tankInTurn) {
        var tankIndex = _cinemachineTargetGroup.FindMember(tankInTurn.transform);
        var secondTankIndex = Mathf.Abs(tankIndex - 1);
        _cinemachineTargetGroup.m_Targets[tankIndex].weight = 1;
        _cinemachineTargetGroup.m_Targets[secondTankIndex].weight = 0;
    }

    private void OnTanksCreated(ITank firstTank, ITank secondTank) {
        _cinemachineTargetGroup.AddMember(firstTank.transform, 1f, firstTank.MaxFuel);
        _cinemachineTargetGroup.AddMember(secondTank.transform, 0f, secondTank.MaxFuel);
    }
}