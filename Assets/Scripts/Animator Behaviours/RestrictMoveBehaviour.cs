using UnityEngine;

public class RestrictMoveBehaviour : StateMachineBehaviour
{
    [SerializeField] private bool _enableRestriction = false;

    private MoveRestrictor _moveRestrictor;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_moveRestrictor == null)
        {
            _moveRestrictor = animator.GetComponent<MoveRestrictor>();
        }

        _moveRestrictor.enabled = _enableRestriction;
    }
}
