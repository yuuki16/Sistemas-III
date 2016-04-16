using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour 
{
    public GameObject pauseButton; 

    public void RestartGame()
    {
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene("Main");
        pauseButton.SetActive(false);
    }
}
