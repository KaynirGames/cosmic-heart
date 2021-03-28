using UnityEngine;

public class RollDecisionBehaviour : StateMachineBehaviour
{
    [SerializeField] private float _minRollValue = 0f;
    [SerializeField] private float _maxRollValue = 1f;
    [SerializeField] private float _nextRollDelay = .5f;
    [SerializeField] private string _decisionRollParameter = "DecisionRoll";

    private float _currentRoll;
    private Timer _nextRollTimer;
    private bool _isUnscaled;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (_nextRollTimer == null)
        {
            _nextRollTimer = new Timer(_nextRollDelay);
            _isUnscaled = animator.updateMode == AnimatorUpdateMode.UnscaledTime;
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (_nextRollTimer.Elapsed)
        {
            _currentRoll = Random.Range(_minRollValue, _maxRollValue);
            animator.SetFloat(_decisionRollParameter, _currentRoll);
            _nextRollTimer.Reset();
        }

        _nextRollTimer.Tick(_isUnscaled);
    }
}
