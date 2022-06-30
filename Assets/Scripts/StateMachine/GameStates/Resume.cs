using UnityEngine;

public class Resume : IState {
    public static bool Active { get; private set; }

    public void Tick() {
    }

    public void OnEnter() {
        Active = true;
        Time.timeScale = 0f;
    }

    public void OnExit() {
        Active = false;
        Time.timeScale = 1f;
    }
}