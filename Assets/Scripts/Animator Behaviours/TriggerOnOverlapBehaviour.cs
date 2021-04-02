using UnityEngine;

public class TriggerOnOverlapBehaviour : StateMachineBehaviour
{
    [SerializeField] private string _triggerParameter = "Default";

    private IOverlapChecker _overlapChecker;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_overlapChecker == null)
        {
            _overlapChecker = animator.GetComponent<IOverlapChecker>();
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_overlapChecker.GetOverlapStatus())
        {
            animator.SetTrigger(_triggerParameter);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.ResetTrigger(_triggerParameter);
    }
}
