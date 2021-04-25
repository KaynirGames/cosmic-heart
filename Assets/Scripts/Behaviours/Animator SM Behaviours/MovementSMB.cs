using UnityEngine;

public class MovementSMB : StateMachineBehaviour
{
    private IDirectionHandler _directionHandler;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_directionHandler == null)
        {
            _directionHandler = animator.GetComponent<IDirectionHandler>();
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _directionHandler.SetDirection(Vector3.zero);
    }
}
