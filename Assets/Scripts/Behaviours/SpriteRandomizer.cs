using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteRandomizer : MonoBehaviour
{
    [SerializeField] private Sprite[] _spriteVariations = null;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (_spriteVariations.Length > 0)
        {
            int index = Random.Range(0, _spriteVariations.Length);
            _spriteRenderer.sprite = _spriteVariations[index];
        }
    }
}
