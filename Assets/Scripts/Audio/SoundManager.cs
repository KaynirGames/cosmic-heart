using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum SoundChannel
    {
        First = 0,
        Second = 1,
        Third = 2
    }

    [SerializeField] private AudioSource _musicChannel = null;
    [SerializeField] private List<AudioSource> _soundChannels = null;
    [SerializeField] private AudioSourceFader _audioSourceFader = null;

    private Coroutine _musicRoutine;
    private float _musicVolume;

    #region Singleton
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    private void Start()
    {
        _musicVolume = _musicChannel.volume;
    }

    public void PlayMusic(AudioClip clip, bool loop = false)
    {
        if (_musicRoutine != null)
        {
            StopCoroutine(_musicRoutine);
        }

        _musicRoutine = StartCoroutine(PlayMusicCO(clip, loop));
    }

    public void PlayOneShot(AudioClip clip, float volumeScale, SoundChannel channel)
    {
        GetSource(channel).PlayOneShot(clip,
                                       volumeScale);
    }

    public void PlayOneShot(SoundSO soundSO)
    {
        PlayOneShot(soundSO.GetAudioClip(),
                    soundSO.VolumeScale,
                    soundSO.SoundChannel);
    }

    private AudioSource GetSource(SoundChannel channel)
    {
        return _soundChannels[(int)channel];
    }

    private IEnumerator PlayMusicCO(AudioClip music, bool loop)
    {
        yield return _audioSourceFader.FadeOutCO(_musicChannel);
        yield return _audioSourceFader.FadeInCO(_musicChannel,
                                                music,
                                                _musicVolume,
                                                loop);
    }
}