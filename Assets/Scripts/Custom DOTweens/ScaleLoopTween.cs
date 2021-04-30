using DG.Tweening;
using UnityEngine;

public class ScaleLoopTween : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform = null;
    [SerializeField] private float _endScale = 1.2f;
    [SerializeField] private float _scaleDuration = 1f;
    [SerializeField] private LoopType _loopType = LoopType.Yoyo;
    [SerializeField] private int _loopAmount = -1;

    private void OnEnable()
    {
        HandleScaleLoop();
    }

    public void HandleScaleLoop()
    {
        _targetTransform.DOScale(_endScale, _scaleDuration)
                        .SetLoops(_loopAmount, _loopType);
    }
}
