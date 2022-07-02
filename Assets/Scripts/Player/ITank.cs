using UnityEngine;

public interface ITank {
    Transform transform { get; }
    GameObject gameObject { get; }
    float MaxFuel { get; }
    bool HasFuel { get; }
    float CurrentFuel { get; }
    void UseFuel(float amount);
    void SetMovementRangeDisplay(bool state);
}