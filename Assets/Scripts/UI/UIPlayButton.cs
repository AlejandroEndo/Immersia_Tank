using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIPlayButton : MonoBehaviour {
    public static Difficulty SelectedDifficulty;

    [SerializeField] private Difficulty _difficulty;
    [SerializeField] private TMP_Text text;

    private void Awake() {
        GetComponent<Button>().onClick.AddListener(() => SelectedDifficulty = _difficulty);
    }

    private void OnValidate() {
        if (text == null) {
            text = GetComponentInChildren<TMP_Text>();
        }

        if (!text.text.Equals(_difficulty.ToString())) {
            text.SetText(_difficulty.ToString());
        }
    }
}