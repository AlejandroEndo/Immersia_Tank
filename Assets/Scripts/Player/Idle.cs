public class Idle : IState {
    private MovementRange _movementRange;

    public Idle(MovementRange movementRange) {
        _movementRange = movementRange;
    }

    public void Tick() {
    }

    public void OnEnter() {
        _movementRange.gameObject.SetActive(false);
    }

    public void OnExit() {
    }
}