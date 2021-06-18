using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleColorHandler : MonoBehaviour, IColorHandler
{
    private ParticleSystem _particles;
    private ParticleSystem.MainModule _mainModule;

    private void Awake()
    {
        _particles = GetComponent<ParticleSystem>();
        _mainModule = _particles.main;
    }

    public void SetColor(Color color)
    {
        _mainModule.startColor = color;
    }

    public Color GetColor()
    {
        return _mainModule.startColor.color;
    }
}