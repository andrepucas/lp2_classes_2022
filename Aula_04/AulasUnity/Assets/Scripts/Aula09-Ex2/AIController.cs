using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private IEnumerable<AnimalsAI> _animalAIs;

    private void Awake()
    {
        _animalAIs = new List<AnimalsAI>()
        {
            new SheepAI(),
            new WolvesAI()
        };
    }

    private void Start() => StartCoroutine(TakeTurns());

    private IEnumerator TakeTurns()
    {
        YieldInstruction wfs = new WaitForSeconds(2);
        
        while (true)
        {
            foreach (AnimalsAI f_animal in _animalAIs)
                f_animal.TakeTurn();

            yield return wfs;
        }
        
    }
}
