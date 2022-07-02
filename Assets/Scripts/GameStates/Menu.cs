using UnityEngine.SceneManagement;

public class Menu : IState {
    public void Tick() {
    }

    public void OnEnter() {
        UIPlayButton.SelectedGameMode = GameMode.None;
        SceneManager.LoadSceneAsync("Menu");
    }

    public void OnExit() {
    }
}