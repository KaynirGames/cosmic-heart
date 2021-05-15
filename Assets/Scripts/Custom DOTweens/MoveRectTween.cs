using DG.Tweening;
using UnityEngine;

public class MoveRectTween : BaseTween
{
    [Header("Move Settings:")]
    [SerializeField] private RectTransform _targetRect = null;
    [SerializeField] private Vector2 _initialPosition = Vector2.zero;
    [SerializeField] private float _moveDuration = .5f;

    protected override Tween CreateTween()
    {
        Vector2 endPos = _targetRect.anchoredPosition;
        _targetRect.anchoredPosition = _initialPosition;

        return _targetRect.DOAnchorPos(endPos, _moveDuration);
    }
}
