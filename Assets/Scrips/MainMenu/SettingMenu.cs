using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public Toggle muteToggle;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("muted"))
            muteToggle.isOn = true;
        else
            muteToggle.isOn = false;

        if (PlayerPrefs.HasKey("volume"))
            volumeSlider.value = PlayerPrefs.GetFloat("volume");
        else
            volumeSlider.value = 0.5f;

    }
    
    public void CurrentVolume(float volume)
    {
        audioMixer.SetFloat("currentVol", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("volume", volume);

    }

    public void MuteToggle(bool muted)
    {
        if (muted)
        {
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("muted", 0);
        }
        else
        {
            AudioListener.volume = 1;
            PlayerPrefs.DeleteKey("muted");
        }
    }
}
