using UnityEngine;

public class MoveTransform : BaseMove
{
    private void Update()
    {
        transform.Translate(_currentVelocity);
    }
}