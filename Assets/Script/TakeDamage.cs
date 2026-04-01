using Unity.VisualScripting;
using UnityEngine;

public class TakeDamage : MonoBehaviour, IDamageTaken
{
    public EntityBaseData data;
    private int currentHP;
    public GameObject prefab;

    void OnEnable()
    {
        currentHP = data.healthPoint;
    }
    public void resolveDamage(DataDamage damageData)
    {
        currentHP -= damageData.damage;

        Debug.Log("Damage: " + damageData.damage);

        if (currentHP <= 0)
        {
            Die();
        }

        if (damageData.pushBack)
        {
            PushBack(damageData.pushBackRate);
        }
    }

    void Die()
    {
        EnemyPoolManager.Instance.Return(prefab, gameObject);
    }

    void PushBack(int pushBackRate)
    {
        int i = Random.Range(1, 101);
        if(i > pushBackRate) return;
        transform.Translate(new Vector2(-data.moveDirection, 0));
    }
    
}