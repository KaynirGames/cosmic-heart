using UnityEngine;

public class TriggerOnRollSMB : StateMachineBehaviour
{
    [SerializeField] private float _minRollValue = 0f;
    [SerializeField] private float _maxRollValue = 1f;
    [SerializeField] private Vector2 _requiredRollRange = new Vector2(0f, 1f);
    [SerializeField] private float _nextRollDelay = .5f;
    [SerializeField] private string _triggerParameter = "Trigger";

    private Timer _nextRollTimer;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (_nextRollTimer == null)
        {
            bool unscaled = animator.updateMode == AnimatorUpdateMode.UnscaledTime;
            _nextRollTimer = new Timer(_nextRollDelay, unscaled);
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (_nextRollTimer.Elapsed)
        {
            float roll = Random.Range(_minRollValue, _maxRollValue);

            if (roll.InRange(_requiredRollRange.x, _requiredRollRange.y))
            {
                animator.SetTrigger(_triggerParameter);
            }

            _nextRollTimer.Reset();
        }

        _nextRollTimer.Tick();
    }
}
