using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] StageData waweTime;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float hpPercentToSummon;
    [SerializeField] StageData waweHP;

    void Awake()
    {
        
    }

    void Start()
    {
        foreach (var spawn in waweTime.spawns)
        {
            StartCoroutine(SpawnRoutine(spawn));
        }
    }

    IEnumerator SpawnRoutine(EnemySpawnData spawn)
    {
        yield return new WaitForSeconds(spawn.startTime);

        if (spawn.infinite)
        {
            while (true)
            {
                Spawn(spawn);

                float delay = Random.Range(spawn.minDelay, spawn.maxDelay);
                yield return new WaitForSeconds(delay);
            }
        }
        else
        {
            Spawn(spawn);
        }
    }

    void Spawn(EnemySpawnData spawn)
    {
        for (int i = 0; i < spawn.spawnCount; i++)
        {
            GameObject enemy = EnemyPoolManager.Instance.Get(spawn.enemyPrefab);

            enemy.transform.position = spawnPoint.position;
            enemy.transform.rotation = Quaternion.identity;
        }
    }

    public void OnBaseDamaged()
    {
        
        foreach(var spawn in waweHP.spawns)
        {
            StartCoroutine(SpawnRoutine(spawn));
        }
    }
}