using UnityEngine.SceneManagement;

public class Menu : IState {
    public void Tick() {
    }

    public void OnEnter() {
        UIPlayButton.SelectedDifficulty = Difficulty.None;
        SceneManager.LoadSceneAsync("Menu");
    }

    public void OnExit() {
    }
}