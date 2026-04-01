using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;

public class EnemyPoolManager : MonoBehaviour
{
    public static EnemyPoolManager Instance;

    Dictionary<GameObject, ObjectPool<GameObject>> pools =
        new Dictionary<GameObject, ObjectPool<GameObject>>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    ObjectPool<GameObject> CreatePool(GameObject prefab)
    {
        return new ObjectPool<GameObject>(
            () => {
            GameObject obj = Instantiate(prefab);
            obj.GetComponent<TakeDamage>().prefab = prefab;
            return obj;
            },
            obj => obj.SetActive(true),
            obj => obj.SetActive(false),
            obj => Destroy(obj),
            false,
            10,
            100
        );
    }

    public GameObject Get(GameObject prefab)
    {
        if (!pools.ContainsKey(prefab))
        {
            pools[prefab] = CreatePool(prefab);
        }

        return pools[prefab].Get();
    }

    public void Return(GameObject prefab, GameObject obj)
    {
        if (pools.TryGetValue(prefab, out var pool))
        {
            pool.Release(obj);
        }
        else
        {
            Destroy(obj);
        }
    }
}