using UnityEngine;
using UnityEngine.UI;

public class SettingsLoader : MonoBehaviour
{
    private const string SETTINGS_FILE = "Settings.sav";

    [SerializeField] private AudioVolumeControl _musicControl = null;
    [SerializeField] private AudioVolumeControl _sfxControl = null;
    [SerializeField] private AudioVolumeControl _masterControl = null;
    [Space]
    [SerializeField] private Slider _musicSlider = null;
    [SerializeField] private Slider _sfxSlider = null;
    [SerializeField] private Toggle _masterToggle = null;

    private void Awake()
    {
        SaveSystem.Init();
    }

    private void Start()
    {
        LoadSettings();
    }

    public void SaveSettings()
    {
        SettingsData data = new SettingsData(_musicControl.GetVolume(),
                                             _sfxControl.GetVolume(),
                                             _masterControl.IsOn);

        SaveSystem.SaveData(data, SETTINGS_FILE);
    }

    public void LoadSettings()
    {
        SettingsData data = (SettingsData)SaveSystem.LoadData(SETTINGS_FILE);

        if (data == null)
        {
            data = new SettingsData();
        }

        _musicSlider.value = data.MusicVolume;
        _sfxSlider.value = data.SFXVolume;
        _masterToggle.isOn = data.IsAudioOn;
    }
}
