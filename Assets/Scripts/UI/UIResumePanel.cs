using System;
using UnityEngine;
using UnityEngine.UI;

public class UIResumePanel : UIPanel {
    [SerializeField] private Button goToMenuButton;

    private void Awake() =>
        goToMenuButton.onClick.AddListener(() => UIController.SelectedUIButton = SelectedUIButton.GoToMenu);

    protected override void OnGameStateChanged(IState state) => panel.SetActive(state is Resume);
}