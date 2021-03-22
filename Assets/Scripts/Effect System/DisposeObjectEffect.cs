using UnityEngine;

public class DisposeObjectEffect : BaseEffect
{
    public override void Activate(GameObject target)
    {
        target.Dispose();
    }
}
