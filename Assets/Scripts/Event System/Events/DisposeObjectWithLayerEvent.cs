using UnityEngine;

public class DisposeObjectWithLayerEvent : BaseEvent
{
    [SerializeField] private LayerMask _layers = 0;

    protected override void Invoke(GameObject target)
    {
        if (target.InLayers(_layers))
        {
            target.Dispose();
        }
    }
}
