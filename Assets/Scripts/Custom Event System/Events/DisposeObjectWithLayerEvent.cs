using UnityEngine;

public class DisposeObjectWithLayerEvent : BaseEvent
{
    [SerializeField] private LayerMask _layers = 0;

    public override void TryInvoke(GameObject target)
    {
        if (target.InLayers(_layers))
        {
            target.Dispose();
        }
    }
}
