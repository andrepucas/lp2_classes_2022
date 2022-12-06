using UnityEngine;

public class Flash : Superpower
{
    [SerializeField] private float _speed;

    public override void Activate()
    {
        BoostSpeed(_speed);
        LightMyFire();
    }
}