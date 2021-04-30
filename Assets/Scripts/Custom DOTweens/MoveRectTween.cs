using DG.Tweening;
using UnityEngine;

public class MoveRectTween : MonoBehaviour
{
    [SerializeField] private RectTransform _targetRect = null;
    [SerializeField] private RectTransform _rectInitialPoint = null;
    [SerializeField] private float _moveDuration = .5f;
    [SerializeField] private Ease _ease = Ease.Unset;

    private void OnEnable()
    {
        MoveRect();
    }

    public void MoveRect()
    {
        _targetRect.DOAnchorPos(_rectInitialPoint.anchoredPosition, _moveDuration)
                   .SetEase(_ease)
                   .From();
    }
}
