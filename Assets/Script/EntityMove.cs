using UnityEngine;

public class EntityMove : MonoBehaviour
{
    [SerializeField] private Transform enemyBuilding;
    [SerializeField] private AllyData data;
    [SerializeField] private BoxCollider2D box;
    [SerializeField] private LayerMask layer;

    Vector2 velocity;
    float skinWidth = 0.02f;

    void Update()
    {
        velocity.x = data.movementSpeed * data.moveDirection * Time.deltaTime;
        Move(velocity);
    }

    void Move(Vector2 move)
    {
        HandleHorizontalCollision(ref move);
        transform.Translate(move);
    }

    void HandleHorizontalCollision(ref Vector2 move)
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            box.bounds.center,
            box.bounds.size,
            0,
            Vector2.right * data.moveDirection,
            Mathf.Abs(move.x) + skinWidth,
            layer
        );

        if (hit)
        {
            move.x = 0;
            velocity.x = 0;
        }
    }
}