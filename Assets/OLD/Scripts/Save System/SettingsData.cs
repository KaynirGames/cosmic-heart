using UnityEngine;

[System.Serializable]
public class SettingsData
{
    [SerializeField] private float _musicVolume = 0f;
    [SerializeField] private float _sfxVolume = 0f;
    [SerializeField] private bool _isAudioOn = true;

    public float MusicVolume => _musicVolume;
    public float SFXVolume => _sfxVolume;

    public bool IsAudioOn => _isAudioOn;

    public SettingsData(float musicVol, float sfxVol, bool isAudioOn)
    {
        _musicVolume = musicVol;
        _sfxVolume = sfxVol;
        _isAudioOn = isAudioOn;
    }

    public SettingsData() : this(1f, 1f, false) { }
}
