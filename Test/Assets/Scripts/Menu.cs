using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour 
{
    public Canvas exit, about;
    public Button btPlay, btQuit, btAbout, btConfig;

    int language;
	// Use this for initialization
	void Start () 
	{
        exit = exit.GetComponent<Canvas>();
        btPlay = btPlay.GetComponent<Button>();
        btQuit = btQuit.GetComponent<Button>();

        if (PlayerPrefs.HasKey("Language"))
        {
            language = PlayerPrefs.GetInt("Language");
        }
        exit.enabled = false;
        about.enabled = false;
	}
	
    public void exitPress()
    {
        exit.enabled = true;
        controlsControl(false);
    }

    public void noPress()
    {
        exit.enabled = false;
        controlsControl(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void showAbout()
    {
        about.enabled = true;
        controlsControl(false);
    }

    public void returnFromAbout()
    {
        about.enabled = false;
        controlsControl(true);
    }

    public void showSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    void controlsControl(bool status)
    {
        btPlay.enabled = status;
        btConfig.enabled = status;
        btAbout.enabled = status;
        btQuit.enabled = status;
    }

}
