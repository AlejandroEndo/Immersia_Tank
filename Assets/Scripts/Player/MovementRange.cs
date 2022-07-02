using UnityEngine;

public class MovementRange : MonoBehaviour {
    public void SetSize(float range) {
        transform.localScale = new Vector3(range, 0.1f, range);
    }
}