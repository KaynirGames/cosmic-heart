using UnityEngine;

public class PlaySoundEvent : BaseEvent
{
    [SerializeField] private SoundSO _soundSO = null;

    private SoundManager _soundManager;

    private void Start()
    {
        _soundManager = SoundManager.Instance;
    }

    protected override void Invoke(GameObject target)
    {
        _soundManager.PlaySound(_soundSO);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        _eventMode = EventMode.None;
    }
#endif
}