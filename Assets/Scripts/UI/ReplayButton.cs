using UnityEngine.UI;

public class ReplayButton : Button {
    private static ReplayButton _instance;
    public static bool Pressed => _instance != null && _instance.IsPressed();

    protected override void OnEnable() {
        _instance = this;
        base.OnEnable();
    }
}