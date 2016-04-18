using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour 
{
    public Slider slAudio, slLight;
    public Dropdown ddLanguage;

    int language;
	// Use this for initialization
	void Start () 
	{
        //0: English, 1: Japanese
        if (PlayerPrefs.HasKey("Language"))
        {
            language = PlayerPrefs.GetInt("Language");
        }
        else
        {
            language = 0;
        }

        ddLanguage.value = language;

       
    }  
    
    
    public void returnHome()
    {
        SceneManager.LoadScene("Menu");
    }

    public void languageChange()
    {
        PlayerPrefs.SetInt("Language", ddLanguage.value);
    }
}
