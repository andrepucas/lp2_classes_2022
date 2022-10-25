using UnityEngine;

public class Attributes : MonoBehaviour
{
    [SerializeField]
    [Range(0, 500)]
    private int _variable;
}
