using UnityEngine;

public class SheepAI : AnimalsAI
{
    protected override void Move()
    {
        Debug.Log("Sheep moving");
    }

    protected override void TryEat()
    {
        Debug.Log("Sheep trying to eat");
    }

    protected override void TryReproduce()
    {
        Debug.Log("Sheep trying to reproduce");
    }
}
