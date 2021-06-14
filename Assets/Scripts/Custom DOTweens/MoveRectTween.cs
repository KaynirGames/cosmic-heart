using DG.Tweening;
using UnityEngine;

public class MoveRectTween : BaseTween
{
    [Header("Move Settings:")]
    [SerializeField] private RectTransform _targetRect = null;
    [SerializeField] private Vector2 _startPosition = Vector2.zero;

    protected override Tween CreateTween()
    {
        Vector2 endPos = _targetRect.anchoredPosition;
        _targetRect.anchoredPosition = _startPosition;

        return _targetRect.DOAnchorPos(endPos, _duration);
    }
}