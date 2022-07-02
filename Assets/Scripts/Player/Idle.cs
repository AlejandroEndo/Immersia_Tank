using UnityEngine.AI;

public class Idle : IState {
    private ITank _tank;

    public Idle(ITank tank) {
        _tank = tank;
    }

    public void Tick() {
    }

    public void OnEnter() {
        _tank.SetMovementRangeDisplay(false);
    }

    public void OnExit() {
    }
}