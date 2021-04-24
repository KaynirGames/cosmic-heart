using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TriggerExitEventHandler2D : BaseEventHandler
{
    private Collider2D _collider2D;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
        _collider2D.isTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InvokeEvents(collision.gameObject);
    }
}
