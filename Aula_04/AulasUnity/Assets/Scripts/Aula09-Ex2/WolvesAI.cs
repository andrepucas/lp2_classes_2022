using UnityEngine;

public class WolvesAI : AnimalsAI
{
    protected override void SelectTarget()
    {
        Debug.Log("Wolf selecting target");
    }
    
    protected override void Move()
    {
        Debug.Log("Wolf moving");
    }

    protected override void TryEat()
    {
        Debug.Log("Wolf trying to eat");
    }

    protected override void TryReproduce()
    {
        Debug.Log("Wolf trying to reproduce");
    }
}
