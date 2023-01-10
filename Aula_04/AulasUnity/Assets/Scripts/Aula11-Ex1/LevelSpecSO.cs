using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Spec")]
public class LevelSpecSO : ScriptableObject
{
    [SerializeField] private Vector2[] _enemySpawnPoints;
    [SerializeField] private Color _levelColor;

    public IEnumerable<Vector2> EnemySpawnPoints => _enemySpawnPoints;
    public Color LevelColor => _levelColor;
}
