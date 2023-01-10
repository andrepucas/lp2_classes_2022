using System.Collections;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform _enemiesFolder;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private LevelSpecSO[] _levelSpecs;
    [SerializeField] private float _levelTransition = 3;

    private void Awake() => StartCoroutine(CycleLevels());

    private IEnumerator CycleLevels()
    {
        YieldInstruction _wfs = new WaitForSeconds(_levelTransition);

        while (true)
        {
            foreach(LevelSpecSO level in _levelSpecs)
            {
                foreach(Transform enemyInstantiated in _enemiesFolder)
                    Destroy(enemyInstantiated.gameObject);

                Camera.main.backgroundColor = level.LevelColor;

                foreach(Vector2 f_pos in level.EnemySpawnPoints)
                    Instantiate(_enemyPrefab, f_pos, Quaternion.identity, _enemiesFolder);

                yield return _wfs;
            }
        }
    }
}
