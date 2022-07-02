using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIPlayButton : MonoBehaviour {
    public static GameMode SelectedGameMode;

    [FormerlySerializedAs("_difficulty")] [SerializeField] private GameMode gameMode;
    [SerializeField] private TMP_Text text;

    private void Awake() {
        GetComponent<Button>().onClick.AddListener(() => SelectedGameMode = gameMode);
    }

    private void OnValidate() {
        if (text == null) {
            text = GetComponentInChildren<TMP_Text>();
        }

        if (!text.text.Equals(gameMode.ToString())) {
            text.SetText(gameMode.ToString());
        }
    }
}