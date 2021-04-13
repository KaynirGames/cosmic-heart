using UnityEngine;

[CreateAssetMenu(fileName = "New Sound", menuName = "Scriptable Objects/Audio/Sound SO")]
public class SoundSO : ScriptableObject
{
    [SerializeField] private AudioClip[] _clipVariations = null;
    [SerializeField, Range(0f, 1f)] private float _volumeScale = 1f;
    [SerializeField] private SoundManager.SoundChannel _soundChannel = SoundManager.SoundChannel.First;

    public float VolumeScale => _volumeScale;
    public SoundManager.SoundChannel SoundChannel => _soundChannel;

    public AudioClip GetAudioClip()
    {
        int random = Random.Range(0, _clipVariations.Length);

        return _clipVariations.Length > 0
            ? _clipVariations[random]
            : null;
    }
}
