using UnityEngine;

public class ScaleRandomizer2D : MonoBehaviour
{
    private const int SCALE_PRECISION = 100;

    [SerializeField] private float _minScale = 1f;
    [SerializeField] private float _maxScale = 1f;
    [SerializeField] private ScaleAxis _scaleAxis = ScaleAxis.Both;

    private void Start()
    {
        transform.localScale = GetScaleVector(_scaleAxis);
    }

    private Vector2 GetScaleVector(ScaleAxis scaleAxis)
    {
        float scale = Random.Range(_minScale, _maxScale)
                            .Precise(SCALE_PRECISION);

        switch (scaleAxis)
        {
            default:
                return new Vector2(scale, scale);
            case ScaleAxis.X:
                return new Vector2(scale, transform.localScale.y);
            case ScaleAxis.Y:
                return new Vector2(transform.localScale.x, scale);
        }
    }

    private enum ScaleAxis
    {
        X,
        Y,
        Both
    }
}
