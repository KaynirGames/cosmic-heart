using UnityEngine;

public class MovementSMB : StateMachineBehaviour
{
    private BaseMoveHandler _moveHandler;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_moveHandler == null)
        {
            _moveHandler = animator.GetComponent<BaseMoveHandler>();
        }

        _moveHandler.enabled = true;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _moveHandler.SetDirection(Vector3.zero);
        _moveHandler.enabled = false;
    }
}
