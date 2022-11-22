using UnityEngine;

public class ConsoleMessages : MonoBehaviour
{
    private void OnEnable() => EventMaster.KeyPress += PrintKey;
    private void OnDisable() => EventMaster.KeyPress -= PrintKey;

    private void PrintKey(char key) => Debug.Log(key);
}
