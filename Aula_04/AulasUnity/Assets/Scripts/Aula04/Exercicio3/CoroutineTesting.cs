using System.Collections;
using UnityEngine;

public class CoroutineTesting : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(HelloCoroutine());
        StartCoroutine(CountTo30());
    }


    private IEnumerator HelloCoroutine()
    {
        WaitForSeconds wfs = new WaitForSeconds(4);
        
        while (true)
        {
            Debug.Log("Hello");
            yield return wfs;
        }
    }

    private IEnumerator CountTo30()
    {
        int seconds = 0;
        WaitForSeconds wfs = new WaitForSeconds(1);
        
        while (true)
        {
            Debug.Log(seconds++);

            if (seconds > 10) StopCoroutine("Test");
            if (seconds > 30) StopAllCoroutines();

            yield return wfs;
        }
    }

    private IEnumerator BeingPressed()
    {
        CustomYieldInstruction waitForPress = new WaitForPress();
        while (true)
        {
            yield return waitForPress;
            Debug.Log("Estou a ser pressionado!! Larga-me!!");
        }
    }
}
