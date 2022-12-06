using UnityEngine;

public class RotateBehaviour : MonoBehaviour, IAnimateBehaviour
{
    public void Animate() => transform.Rotate(Vector3.one);
}
