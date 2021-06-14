using DG.Tweening;
using UnityEngine;

public abstract class BaseTween : MonoBehaviour
{
    [Header("Base Settings:")]
    [SerializeField] protected float _duration = 1f;
    [SerializeField] protected Ease _ease = Ease.Unset;
    [SerializeField] protected int _loopAmount = 0;
    [SerializeField] protected LoopType _loopType = LoopType.Restart;
    [SerializeField] protected bool _playOnEnable = true;

    protected Tween _tween;

    public void PlayTween()
    {
        _tween = CreateTween().SetEase(_ease)
                              .SetLoops(_loopAmount, _loopType);
    }

    protected abstract Tween CreateTween();

    private void OnEnable()
    {
        if (_playOnEnable)
        {
            PlayTween();
        }
    }

    private void OnDisable()
    {
        _tween?.Kill(true);
    }
}
