using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Menu : MonoBehaviour 
{
    public Canvas exit, about, instructions;
    public Button btPlay, btQuit, btAbout, btConfig, btInstructions;
    public Text txtExit, txtNo, txtYes, txtDeveloped, txtVersion;
    public LanguageController languageController;
    public Transform musicPrefab;

    string strValue; 
    int language;
    float volumeLevel;
    Dictionary<string, string> langContent = new Dictionary<string, string>();
    // Use this for initialization
    void Start () 
	{
        //music volume
        if (PlayerPrefs.HasKey("CurrVol"))
        {
            volumeLevel = PlayerPrefs.GetFloat("CurrVol");
        }
        else
        {
            volumeLevel = 1.0f;
        }
        //language
        if (PlayerPrefs.HasKey("Language"))
        {
            language = PlayerPrefs.GetInt("Language");
        }
        else
        {
            language = 0;
        }

        langContent = languageController.languageChange(language);
        //Play Button
        langContent.TryGetValue("btPlay", out strValue);
        btPlay.GetComponentInChildren<Text>().text = strValue;
        //Exit Text
        langContent.TryGetValue("txtSalir", out strValue);
        txtExit.text = strValue;
        //No Text
        langContent.TryGetValue("txtNo", out strValue);
        txtNo.text = strValue;
        //Yes Text
        langContent.TryGetValue("txtYes", out strValue);
        txtYes.text = strValue;
        //Developed Text
        langContent.TryGetValue("txtDeveloped", out strValue);
        txtDeveloped.text = strValue;
        //Version Text
        langContent.TryGetValue("txtVersion", out strValue);
        txtVersion.text = strValue;

        //set music
        if (!GameObject.FindGameObjectWithTag("Music"))
        {
            var mManager = Instantiate(musicPrefab, transform.position, Quaternion.identity);
            mManager.name = musicPrefab.name;
            DontDestroyOnLoad(mManager);
        }
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().volume = volumeLevel;
        //hide popups
        exit.enabled = false;
        about.enabled = false;
        instructions.enabled = false;
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

    public void returnFromInstructions()
    {
        instructions.enabled = false;
        controlsControl(true);
    }
    public void showInstructions()
    {
        instructions.enabled = true;
        controlsControl(false);

    }

    void controlsControl(bool status)
    {
        btPlay.enabled = status;
        btConfig.enabled = status;
        btAbout.enabled = status;
        btQuit.enabled = status;
        btInstructions.enabled = status;
    }

}
