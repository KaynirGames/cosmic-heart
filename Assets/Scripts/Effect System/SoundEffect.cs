using UnityEngine;

[RequireComponent(typeof(AudioVolumeControl))]
public class SoundEffect : BaseEffect
{
    [SerializeField] private AudioClip[] _clipVariations = null;

    private AudioVolumeControl _volumeControl;

    private void Awake()
    {
        _volumeControl = GetComponent<AudioVolumeControl>();
    }

    public override void Activate(GameObject go)
    {
        AudioSource.PlayClipAtPoint(GetRandomClip(),
                                    GetProperTarget(go).transform.position,
                                    _volumeControl.GetVolumePercentage());
    }

    private AudioClip GetRandomClip()
    {
        return _clipVariations?[Random.Range(0,
                                             _clipVariations.Length)];
    }
}