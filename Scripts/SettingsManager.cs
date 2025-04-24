using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Dropdown GraphicsDropdown;
    public Slider BGMVolume, SFXVolume, VoiceVolume;

    [Header("Audio Mixer")]
    public AudioMixer mainAudioMixer;

    void Start()
    {
        LoadSettings();
    }

    // Called when Graphics Dropdown changes
    public void ChangeGraphicsQuality()
    {
        QualitySettings.SetQualityLevel(GraphicsDropdown.value);
       
    }
    // BGM Volume
    public void ChangeBGMVolume()
    {
        mainAudioMixer.SetFloat("BGMVolume", BGMVolume.value);
    }

    // SFX Volume
    public void ChangeSFXVolume()
    {
        mainAudioMixer.SetFloat("SFXVolume", SFXVolume.value);
    }

    // Voice Volume
    public void ChangeVoiceVolume()
    {
        mainAudioMixer.SetFloat("VoiceVolume", VoiceVolume.value);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("GraphicsQuality", GraphicsDropdown.value);
        PlayerPrefs.SetFloat("BGMVolume", BGMVolume.value);
        PlayerPrefs.SetFloat("SFXVolume", SFXVolume.value);
        PlayerPrefs.SetFloat("VoiceVolume", VoiceVolume.value);
        PlayerPrefs.Save();
        Debug.Log("Settings saved!");
    }

    // Load saved settings
    public void LoadSettings()
    {
        GraphicsDropdown.value = PlayerPrefs.GetInt("GraphicsQuality", 0);
        BGMVolume.value = PlayerPrefs.GetFloat("BGMVolume", 1f);
        SFXVolume.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        VoiceVolume.value = PlayerPrefs.GetFloat("VoiceVolume", 1f);

    }


}
