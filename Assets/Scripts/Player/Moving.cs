using UnityEngine;
using UnityEngine.AI;

public class Moving : IState {
    private NavMeshAgent _navMeshAgent;
    private ITank _tank;

    private bool _canMove;

    private Vector3 _previousPos;

    public Moving(NavMeshAgent navMeshAgent, ITank tank) {
        _navMeshAgent = navMeshAgent;
        _tank = tank;
    }

    public void Tick() {
        if (_previousPos != _tank.transform.position) {
            _tank.UseFuel(Vector3.Distance(_previousPos, _tank.transform.position));
        }

        if (!_canMove && _navMeshAgent.remainingDistance < 0.025f) {
            ActivateMovement();
        }

        if (_canMove && Input.GetMouseButtonDown(0)) {
            _navMeshAgent.SetDestination(Pointer.GetNavMeshPosition());
            DeactivateMovement();
        }

        _previousPos = _tank.transform.position;
    }

    private void ActivateMovement() {
        _canMove = true;
        _tank.SetMovementRangeDisplay(true);
        Pointer.ActivatePointer(_tank);
    }

    private void DeactivateMovement() {
        _canMove = false;
        _tank.SetMovementRangeDisplay(false);
        Pointer.DeactivatePointer();
    }

    public void OnEnter() {
        _previousPos = _tank.transform.position;
        _navMeshAgent.enabled = true;
        ActivateMovement();
    }

    public void OnExit() {
        _navMeshAgent.enabled = false;
        DeactivateMovement();
    }
}