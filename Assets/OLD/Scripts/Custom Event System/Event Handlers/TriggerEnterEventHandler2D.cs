using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TriggerEnterEventHandler2D : BaseEventHandler
{
    private Collider2D _collider2D;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
        _collider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InvokeEvents(collision.gameObject);
    }
}
