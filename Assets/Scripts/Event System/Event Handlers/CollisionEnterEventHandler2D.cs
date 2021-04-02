using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollisionEnterEventHandler2D : BaseEventHandler
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        InvokeEvents(collision.gameObject);
    }
}
