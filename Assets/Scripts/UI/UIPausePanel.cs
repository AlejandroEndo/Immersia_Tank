using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIPausePanel : UIPanel {
    [SerializeField] private Button continueButton;
    [SerializeField] private Button goToMenu;
    private void Awake() {
        continueButton.onClick.AddListener(() => UIController.SelectedUIButton = SelectedUIButton.Continue);
        goToMenu.onClick.AddListener(() => UIController.SelectedUIButton = SelectedUIButton.GoToMenu);
    }
    protected override void OnGameStateChanged(IState state) => panel.SetActive(state is Pause);
}