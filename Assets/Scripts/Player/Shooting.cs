using UnityEngine;

public class Shooting : IState {
    private Tank _tank;

    public Shooting(Tank tank) {
        _tank = tank;
    }

    public void Tick() {
        _tank.TowerAimRotation(Pointer.GetMousePosition() - _tank.transform.position);
    }

    public void OnEnter() {
        _tank.RefillFuel();
    }

    public void OnExit() {
        TanksManager.Instance.EndTurn();
    }
}