using UnityEngine;

public interface IPlayer {
    public Transform transform { get; }
    public float MaxFuel { get; }
    public bool HasFuel { get; }
}