using UnityEngine;

public class EnterLevelBehaviour : StateMachineBehaviour
{
    [SerializeField] private string _enterCompleteTrigger = "EnterComplete";

    private IBoundaryChecker _boundaryChecker;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_boundaryChecker == null)
        {
            _boundaryChecker = animator.GetComponent<IBoundaryChecker>();
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_boundaryChecker.IsWithinBounds())
        {
            animator.SetTrigger(_enterCompleteTrigger);
        }
    }
}
