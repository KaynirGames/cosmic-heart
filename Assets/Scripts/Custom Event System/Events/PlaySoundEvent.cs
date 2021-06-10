using UnityEngine;

public class PlaySoundEvent : BaseEvent
{
    [SerializeField] private SoundSO _soundSO = null;

    private SoundManager _soundManager;

    private void Start()
    {
        _soundManager = SoundManager.Instance;
    }

    public override void TryInvoke(GameObject target)
    {
        if (_soundSO != null)
        {
            _soundManager.PlaySound(_soundSO);
        }
    }
}