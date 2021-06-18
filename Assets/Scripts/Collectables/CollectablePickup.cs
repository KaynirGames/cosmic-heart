using UnityEngine;

public class CollectablePickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ICollectable collectable))
        {
            collectable.Collect();
        }
    }
}