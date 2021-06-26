using UnityEngine;

public class MoveTransformTranslate : BaseMoveHandler
{
    [SerializeField] private Space _translateSpace = Space.Self;

    private void Update()
    {
        CalculateVelocity();
        Move();
    }

    protected override void Move()
    {
        transform.Translate(Velocity,
                            _translateSpace);
    }
}