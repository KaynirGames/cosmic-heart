using UnityEngine;

public class MoveTransformTranslate : BaseMoveHandler
{
    [SerializeField] private Space _translateSpace = Space.Self;

    private void Update()
    {
        Move();
    }

    protected override void Move()
    {
        transform.Translate(GetVelocity(),
                            _translateSpace);
    }
}