using UnityEngine;

public class TriggerOverTimeBehaviour : StateMachineBehaviour
{
    [SerializeField] private string _triggerParameter = "Trigger";
    [SerializeField] private float _nextTriggerDelay = .5f;

    private Timer _nextTriggerTimer;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (_nextTriggerTimer == null)
        {
            bool unscaled = animator.updateMode == AnimatorUpdateMode.UnscaledTime;
            _nextTriggerTimer = new Timer(_nextTriggerDelay, unscaled);
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (_nextTriggerTimer.Elapsed)
        {
            animator.SetTrigger(_triggerParameter);
            _nextTriggerTimer.Reset();
        }

        _nextTriggerTimer.Tick();
    }
}
