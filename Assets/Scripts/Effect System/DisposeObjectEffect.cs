using UnityEngine;

public class DisposeObjectEffect : BaseEffect
{
    public override void Activate(GameObject go)
    {
        GetProperTarget(go).Dispose();
    }
}
