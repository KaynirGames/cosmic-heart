using UnityEngine;

public class TransformMovement : BaseMovement
{
    private void Update()
    {
        transform.Translate(_currentVelocity);
    }
}