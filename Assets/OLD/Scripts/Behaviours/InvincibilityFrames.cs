using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class InvincibilityFrames : MonoBehaviour
{
    [SerializeField] private string _regularLayer = "Default";
    [SerializeField] private string _invincibilityLayer = "Undefined";
    [SerializeField] private Color _regularColor = Color.white;
    [SerializeField] private Color _flashColor = Color.white;
    [SerializeField] private float _flashDuration = .15f;
    [SerializeField] private int _flashAmount = 4;

    private SpriteRenderer _spriteRenderer;
    private bool _isInvincible;
    private WaitForSeconds _waitForNextFlash;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _waitForNextFlash = new WaitForSeconds(_flashDuration);
    }

    public void Activate()
    {
        if (!_isInvincible)
        {
            StartCoroutine(InvincibilityCO());
        }
    }

    private IEnumerator InvincibilityCO()
    {
        _isInvincible = true;
        int flashNumber = 0;
        SetLayer(_invincibilityLayer);

        while (flashNumber < _flashAmount)
        {
            SetColor(_flashColor);
            yield return _waitForNextFlash;
            SetColor(_regularColor);
            yield return _waitForNextFlash;
            flashNumber++;
        }

        _isInvincible = false;
        SetLayer(_regularLayer);
    }

    private void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    private void SetLayer(string layer)
    {
        gameObject.layer = LayerMask.NameToLayer(layer);
    }
}
