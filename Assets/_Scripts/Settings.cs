using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class Settings : MonoBehaviour
{

    [SerializeField] private Slider mainVolumeSlider;
    [SerializeField] private Slider effectsVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Toggle fullScreenToggle;

    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private TMP_Dropdown qualityDropdown;

    private bool isFullScreenMode;
    private int fullScreenSave;

    Resolution[] resolutions;

    private void Awake()
    {
        fullScreenSave = PlayerPrefs.GetInt("FullScreenMode");

        if (fullScreenSave == 1)
        {
            fullScreenToggle.isOn = true;
            isFullScreenMode = true;
        }

        else 
        {
            fullScreenToggle.isOn = false;
            isFullScreenMode = false;
        } 

        Screen.fullScreen = isFullScreenMode;


        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
        qualityDropdown.value = PlayerPrefs.GetInt("Quality");        
    }

    private void Start()
    {
        audioMixer.SetFloat("Master", PlayerPrefs.GetFloat("Master"));
        audioMixer.SetFloat("Effects", PlayerPrefs.GetFloat("Effects"));
        audioMixer.SetFloat("Music", PlayerPrefs.GetFloat("Music"));

        mainVolumeSlider.value = PlayerPrefs.GetFloat("Master");
        effectsVolumeSlider.value = PlayerPrefs.GetFloat("Effects");
        musicVolumeSlider.value = PlayerPrefs.GetFloat("Music");    

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);     
        resolutionDropdown.RefreshShownValue();
        if (PlayerPrefs.HasKey("Resolution"))
        {
            Screen.SetResolution(resolutions[PlayerPrefs.GetInt("Resolution")].width, resolutions[PlayerPrefs.GetInt("Resolution")].height, Screen.fullScreen);
            resolutionDropdown.value = PlayerPrefs.GetInt("Resolution");
        }
        else
        {
            Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen);
            resolutionDropdown.value = currentResolutionIndex;
        }
    }


    /*--------------- Audio ---------------*/
    public void MasterAudioSlider(float volume)
    {
        audioMixer.SetFloat("Master", volume);
        PlayerPrefs.SetFloat("Master", volume);
    }
    public void EffectsAudioSlider(float volume)
    {
        audioMixer.SetFloat("Effects", volume);
        PlayerPrefs.SetFloat("Effects", volume);
    }
    public void MusicAudioSlider(float volume)
    {
        audioMixer.SetFloat("Music", volume);
        PlayerPrefs.SetFloat("Music", volume);
    }

    /*--------------- Quality ---------------*/
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("Quality", qualityIndex);
    }

    /*--------------- Screen ---------------*/
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("Resolution", resolutionIndex);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

        if (isFullscreen)
        {
            PlayerPrefs.SetInt("FullScreenMode", 1);
            isFullScreenMode = true;
        }        
        else 
        {
            PlayerPrefs.SetInt("FullScreenMode", 0);
            isFullScreenMode = false;
        }
        
    }
}
