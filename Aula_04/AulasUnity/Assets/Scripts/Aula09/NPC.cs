using UnityEngine;

public class NPC : MonoBehaviour
{
    private IAnimateBehaviour behaviour;

    private void Awake()
    {
        behaviour = GetComponent<IAnimateBehaviour>();
    }

    private void FixedUpdate()
    {
        behaviour?.Animate();
    }
}
