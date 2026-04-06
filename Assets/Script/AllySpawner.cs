using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class AllySpawner : MonoBehaviour, IPointerClickHandler
{
    public GameObject unitPrefab;
    public Transform spawnPoint;

    public void OnPointerClick(PointerEventData eventData)
    {
        Spawn();
    }

    public void Spawn()
    {
            GameObject enemy = EnemyPoolManager.Instance.Get(unitPrefab);

            enemy.transform.position = spawnPoint.position;
            enemy.transform.rotation = Quaternion.identity;
    }



}