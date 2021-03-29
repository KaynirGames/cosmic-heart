using UnityEngine;

public class SoundEffect : BaseEffect
{
    [SerializeField] private SoundSO _soundSO = null;

    private SoundManager _soundManager;

    private void Start()
    {
        _soundManager = SoundManager.Instance;
    }

    public override void Activate(GameObject go)
    {
        _soundManager.PlaySound(_soundSO);
    }
}