using UnityEngine;

public class Shooting : IState {
    private Tank _tank;
    private Vector3 _tankPosition;

    public Shooting(Tank tank) {
        _tank = tank;
    }

    public void Tick() {
        _tank.TowerAimRotation(Pointer.GetMousePosition() - _tankPosition);

        if (Input.GetMouseButtonDown(0)) {
            _tank.StartShotCharge();
        } else if (Input.GetMouseButtonUp(0)) {
            _tank.ReleaseShot();
        }
    }

    public void OnEnter() {
        _tankPosition = _tank.transform.position;
        _tank.RefillFuel();
    }

    public void OnExit() {
    }
}