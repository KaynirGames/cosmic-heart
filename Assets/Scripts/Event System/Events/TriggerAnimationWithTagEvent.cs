using UnityEngine;

public class TriggerAnimationWithTagEvent : BaseEvent
{
    [SerializeField] private string _animationTrigger = null;
    [SerializeField] private string _tagName = null;

    protected override void Invoke(GameObject target)
    {
        if (target.CompareTag(_tagName))
        {
            if (target.TryGetComponent(out Animator animator))
            {
                animator.SetTrigger(_animationTrigger);
            }
        }
    }
}
