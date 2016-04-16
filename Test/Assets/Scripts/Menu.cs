using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour 
{
    public Canvas exit;
    public Button play;
    public Button quit;


	// Use this for initialization
	void Start () 
	{
 //       exit = exit.GetComponent<Canvas>();
 //       play = play.GetComponent<Button>();
 //       quit = quit.GetComponent<Button>();

 //       exit.enabled = false;
	}
	
    public void exitPress()
    {
        exit.enabled = true;
        play.enabled = false;
        quit.enabled = false;

    }

    public void noPress()
    {
        exit.enabled = false;
        play.enabled = true;
        quit.enabled = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
