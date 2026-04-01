using UnityEngine;

public class EntityMove : MonoBehaviour
{
    [SerializeField] private EntityBaseData data;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask layer;

    public Vector2 velocity;
    public RaycastHit2D[] hits = new RaycastHit2D[200];
    public int hitCount;
    Vector2 rayPoint;

    void Update()
    {
        velocity.x = data.movementSpeed * data.moveDirection;
        Move(velocity * Time.deltaTime);
    }

    void Move(Vector2 move)
    {
        HandleHorizontalCollision(ref move);
        transform.Translate(move);
    }

    void HandleHorizontalCollision(ref Vector2 move)
    {
        hitCount = Physics2D.RaycastNonAlloc(
            attackPoint.position,
            Vector2.right * data.moveDirection,
            hits,
            data.attackRange.y,
            layer
        );
        
        if (hitCount > 0)
        {
            move.x = 0;
            velocity.x = 0;
        }
    }
}