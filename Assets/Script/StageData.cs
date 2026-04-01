using UnityEngine;

[CreateAssetMenu(menuName = "Spawn/Stage/Data")]
public class StageData : ScriptableObject
{
    public EnemySpawnData[] spawns;
}