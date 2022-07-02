using UnityEngine.UI;

public class GoToMenuButton : Button {
    private static GoToMenuButton _instance;
    public static bool Pressed => _instance != null && _instance.IsPressed();

    protected override void OnEnable() {
        _instance = this;
        base.OnEnable();
    }
}