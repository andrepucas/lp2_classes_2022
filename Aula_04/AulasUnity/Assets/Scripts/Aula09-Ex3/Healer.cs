using UnityEngine;

public class Healer : Superpower
{
    [SerializeField] private float _health;
    [SerializeField] private float _speedReduction;

    public override void Activate()
    {
        BoostSpeed(_speedReduction);
        Heal(_health);
    }
}