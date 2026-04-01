using UnityEngine;

[CreateAssetMenu(menuName = "Spawn/Enemy/Spawn Data")]
public class EnemySpawnData : ScriptableObject
{
    public GameObject enemyPrefab;
    public float startTime;
    public int spawnCount;
    public float minDelay;
    public float maxDelay;
    public bool infinite;
}