using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicVolumeControl : MonoBehaviour 
{
    AudioSource audioVolume;
    float volumeLevel;

    public Slider slAudio;
    // Use this for initialization
    void Start () 
	{
        audioVolume = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        slAudio = GetComponent<Slider>();
        if (PlayerPrefs.HasKey("CurrVol"))
        {
            volumeLevel = PlayerPrefs.GetFloat("CurrVol");
        }
        else
        {
            volumeLevel = 1.0f;
        }
        slAudio.value = volumeLevel;
    }

    public void setVolume()
    {
        volumeLevel = slAudio.value;
        audioVolume.volume = volumeLevel;
        PlayerPrefs.SetFloat("CurrVol", volumeLevel);
    }

}
