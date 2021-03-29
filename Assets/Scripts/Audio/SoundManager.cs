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

    public void PlayMusic(AudioClip music, bool loop = false)
    {
        if (_musicRoutine != null)
        {
            StopCoroutine(_musicRoutine);
        }

        _musicRoutine = StartCoroutine(PlayMusicRoutine(music, loop));
    }
    
    public void PlaySound(AudioClip sound, float volumeScale = 1f, SoundChannel channel = SoundChannel.First)
    {
        GetSoundSource(channel).PlayOneShot(sound, volumeScale);
    }

    public void PlaySound(SoundSO soundSO)
    {
        PlaySound(soundSO.GetAudioClip(),
                  soundSO.VolumeScale,
                  soundSO.SoundChannel);
    }

    private AudioSource GetSoundSource(SoundChannel channel)
    {
        return _soundChannels[(int)channel];
    }

    private IEnumerator PlayMusicRoutine(AudioClip music, bool loop)
    {
        yield return _audioSourceFader.FadeOut(_musicChannel);
        yield return _audioSourceFader.FadeIn(_musicChannel, music, _musicVolume, loop);
    }
}