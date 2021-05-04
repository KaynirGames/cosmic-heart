using DG.Tweening;
using UnityEngine;

public abstract class BaseTween : MonoBehaviour
{
    [Header("Base Settings:")]
    [SerializeField] protected Ease _ease = Ease.Unset;
    [SerializeField] protected int _loopAmount = 0;
    [SerializeField] protected LoopType _loopType = LoopType.Restart;

    protected Tween _tween;

    public abstract Tween CreateTween();

    protected virtual void OnEnable()
    {
        _tween = CreateTween();
        _tween.Play();
    }

    protected virtual void OnDisable()
    {
        _tween?.Kill(true);
    }
}
