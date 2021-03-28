using UnityEngine;

public class EnemyMoveBehaviour : StateMachineBehaviour
{
    private Enemy _enemy;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_enemy == null)
        {
            _enemy = animator.GetComponent<Enemy>();
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemy.Move();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemy.MoveHandler.SetVelocity(Vector3.zero);
    }
}
