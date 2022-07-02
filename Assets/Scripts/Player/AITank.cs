using UnityEngine;

public class AITank : MonoBehaviour, ITank {
    public float MaxFuel { get; }
    public bool HasFuel { get; }
    public float CurrentFuel { get; }

    public void UseFuel(float amount) {
    }

    public void SetMovementRangeDisplay(bool state) {
    }
}