using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ParallaxHandler : MonoBehaviour
{
    [SerializeField] private Vector2 _parallaxDirection = Vector2.one;
    [SerializeField] private float _parallaxSpeed = .15f;

    private MeshRenderer _meshRenderer;

    private float _offsetX;
    private float _offsetY;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        CalculateOffset();
    }

    private void Update()
    {
        HandleParallax();
    }

    public void SetMaterial(Material material)
    {
        _meshRenderer.material = material;
    }

    private void HandleParallax()
    {
        Vector2 offset = _meshRenderer.material.mainTextureOffset;

        offset.x += _offsetX;
        offset.y += _offsetY;

        _meshRenderer.material.mainTextureOffset = offset;
    }

    private float GetAxisOffset(float axisDirection, float localScale)
    {
        return axisDirection
               * _parallaxSpeed
               * Time.deltaTime
               / localScale;
    }

    private void CalculateOffset()
    {
        _offsetX = GetAxisOffset(_parallaxDirection.x,
                                 transform.localScale.x);

        _offsetY = GetAxisOffset(_parallaxDirection.y,
                                 transform.localScale.y);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        CalculateOffset();
    }
#endif
}