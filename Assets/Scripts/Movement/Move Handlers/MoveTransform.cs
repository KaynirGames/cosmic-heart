using UnityEngine;

public class MoveTransform : BaseMoveHandler
{
    private void Update()
    {
        transform.Translate(GetVelocity(Time.deltaTime));
    }
}