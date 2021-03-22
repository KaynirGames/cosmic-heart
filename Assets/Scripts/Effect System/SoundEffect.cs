using UnityEngine;

[RequireComponent(typeof(VolumeControl))]
public class SoundEffect : BaseEffect
{
    [SerializeField] private AudioClip[] _clipVariations = null;

    private VolumeControl _volumeControl;

    private void Awake()
    {
        _volumeControl = GetComponent<VolumeControl>();
    }

    public override void Activate(GameObject target)
    {
        AudioSource.PlayClipAtPoint(GetRandomClip(),
                                    target.transform.position,
                                    _volumeControl.GetVolumePercentage());
    }

    private AudioClip GetRandomClip()
    {
        return _clipVariations?[Random.Range(0,
                                             _clipVariations.Length)];
    }
}