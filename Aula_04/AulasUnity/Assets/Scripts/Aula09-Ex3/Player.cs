using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IEnumerable <Superpower> _superPowers;
    
    private void Awake() => _superPowers = GetComponents<Superpower>();

    private void Start() => StartCoroutine(ActivatePowers());

    private IEnumerator ActivatePowers()
    {
        YieldInstruction wfs = new WaitForSeconds(3);

        while (true)
        {
            foreach(Superpower f_power in _superPowers)
                f_power.Activate();

            yield return wfs;
        }
    }
}
