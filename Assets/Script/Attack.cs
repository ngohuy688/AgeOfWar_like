using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private EntityBaseData baseData;
    private EntityMove entityMove;
    float attackTimer = 0;


    void Awake()
    {
        entityMove = GetComponent<EntityMove>();
    }

    void Update()
    {
        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            return;
        }
        TryAttack();
    }

    public void TryAttack()
    {
        DataDamage dt = new DataDamage
        {
            damage = baseData.damage,
            pushBack = baseData.pushBack,
            pushBackRate = baseData.pushBackRate,
            attacker = GetComponent<Collider2D>()
        };
        for(int i=0; i<entityMove.hitCount; i++)
        {
            if(entityMove.hits[i].distance < baseData.attackRange.x) continue;
            IDamageTaken sc = entityMove.hits[i].collider.GetComponent<IDamageTaken>();
            if(sc == null) return;
            sc.resolveDamage(dt);
            if(!baseData.AOE) return;
        }
        attackTimer = baseData.attackSpeed;
    }

}