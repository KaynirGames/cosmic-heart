using UnityEngine;

public class PointSpawnArea : BaseSpawnArea
{
    public override Vector3 GetSpawnPosition()
    {
        return transform.position;
    }
}
