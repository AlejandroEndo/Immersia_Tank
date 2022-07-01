using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : IState {
    private List<AsyncOperation> _operations = new List<AsyncOperation>();

    public bool Finish() => _operations.TrueForAll(t => t.isDone);

    public void Tick() {
    }

    public void OnEnter() {
        _operations.Add(SceneManager.LoadSceneAsync("Scenes/Main"));
        _operations.Add(SceneManager.LoadSceneAsync("Scenes/UI", LoadSceneMode.Additive));
    }

    public void OnExit() {
        _operations.Clear();
    }
}