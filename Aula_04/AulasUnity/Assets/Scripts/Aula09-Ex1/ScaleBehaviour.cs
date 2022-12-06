using UnityEngine;

public class ScaleBehaviour : MonoBehaviour, IAnimateBehaviour
{
    private float _angle;
    
    public void Animate()
    {
        transform.localScale = Vector3.one * Mathf.Abs(Mathf.Cos(_angle));
        _angle += Time.deltaTime;
    }
}
