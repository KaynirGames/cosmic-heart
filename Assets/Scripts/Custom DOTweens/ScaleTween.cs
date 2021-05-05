using DG.Tweening;
using UnityEngine;

public class ScaleTween : BaseTween
{
    [Header("Scale Settings:")]
    [SerializeField] private Transform _targetTransform = null;
    [SerializeField] private Vector3 _startScale = Vector3.one;
    [SerializeField] private Vector3 _endScale = Vector3.one;
    [SerializeField] private float _scaleDuration = 1f;

    protected override Tween CreateTween()
    {
        _targetTransform.localScale = _startScale;

        return _targetTransform.DOScale(_endScale, _scaleDuration);
    }
}