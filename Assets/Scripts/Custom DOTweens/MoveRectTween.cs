using DG.Tweening;
using UnityEngine;

public class MoveRectTween : BaseTween
{
    [Header("Move Settings:")]
    [SerializeField] private RectTransform _targetRect = null;
    [SerializeField] private RectTransform _rectInitialPoint = null;
    [SerializeField] private float _moveDuration = .5f;

    protected override Tween CreateTween()
    {
        return _targetRect.DOAnchorPos(_rectInitialPoint.anchoredPosition, _moveDuration)
                          .From();
    }
}
