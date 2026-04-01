using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public GameObject unitPrefab;
    public Transform spawnPoint;

    public int cost = 50;

    public void SpawnUnit()
    {
        // if (MoneyManager.instance.money >= cost)
        // {
        Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity);

        //     MoneyManager.instance.money -= cost;
        // }
    }
}