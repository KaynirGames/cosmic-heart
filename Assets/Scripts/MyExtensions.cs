using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyExtensions
{
    public static Vector3 ClampPosition2D(this Vector3 position, Vector3 minPosition, Vector3 maxPosition)
    {
        position.x = Mathf.Clamp(position.x, minPosition.x, maxPosition.x);
        position.y = Mathf.Clamp(position.y, minPosition.y, maxPosition.y);

        return position;
    }
}
