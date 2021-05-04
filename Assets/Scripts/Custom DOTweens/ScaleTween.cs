using DG.Tweening;
using UnityEngine;

public class ScaleTween : BaseTween
{
    [Header("Scale Settings:")]
    [SerializeField] private Transform _targetTransform = null;
    [SerializeField] private Vector3 _startScale = Vector3.one;
    [SerializeField] private Vector3 _endScale = Vector3.one;
    [SerializeField] private float _scaleDuration = 1f;

    protected override void OnEnable()
    {
        _targetTransform.localScale = _startScale;

        base.OnEnable();
    }

    public override Tween CreateTween()
    {
        return _targetTransform.DOScale(_endScale, _scaleDuration)
                               .SetEase(_ease)
                               .SetLoops(_loopAmount, _loopType);
    }
}