using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
    public Camera camara;
    public GameObject[] objects;
    public Text vidas, scoreText, bestScoreText;
    public GameObject gameOverText, restartButton, pauseButton, musicPlayer;
    public Image[] Hearts;
    public AudioSource audioSource;
    public AudioClip gameMusic, gameOver;

    private float maxAncho;
    private GameObject[] food;
    private GameObject[] fish;

    int vida = 3, score = 0, bestScore = 0;
    GameObject objeto;
    // Use this for initialization
    void Start () 
	{
        if (camara == null)
        {
            camara = Camera.main;
        }
        //establecer tamaño pantalla
        audioSource = musicPlayer.GetComponent<AudioSource>();
        audioSource.clip = gameMusic;
        audioSource.Play();
        Vector3 esquinaSup = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 ancho = camara.ScreenToWorldPoint(esquinaSup);
        float bentoAncho = objects[0].GetComponent<Renderer>().bounds.extents.x;
        maxAncho = ancho.x - bentoAncho;
        pauseButton.SetActive(true);
        //Hearts
        for (int i = 0; i < Hearts.Length; i++)
        {
            Hearts[i].gameObject.SetActive(true);
        }
        //Best Score
        if (PlayerPrefs.HasKey("Score"))
        {
            bestScore = PlayerPrefs.GetInt("Score");
            bestScoreText.text = bestScore.ToString();
        }
        StartCoroutine(Spawn());
    }
	

	void FixedUpdate () 
	{
        vida = int.Parse(vidas.text.Substring(7));
        score = int.Parse(scoreText.text);
     }

    IEnumerator Spawn()
    {
        
        yield return new WaitForSeconds(2.0f);//tiempo de espera para spawnear

        while (vida > 0)
        {
            if (score < 6)//0-5
            {
                objeto = objects[Random.Range(0, 3)];
                objeto.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
            }
            else if (score < 11)//6-10
            {
                objeto = objects[Random.Range(0, 4)];
                objeto.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
            }
            else if (score < 16)//11-15
            {
                objeto = objects[Random.Range(0, 6)];
                objeto.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
                //audioSource.pitch = 2.0f;
            }
            else if (score < 21)//16-20
            {
                objeto = objects[Random.Range(0, 7)];
                objeto.GetComponent<Rigidbody2D>().gravityScale = 0.4f;
            }
            else if (score < 26)//21-25
            {
                objeto = objects[Random.Range(0, 9)];
                objeto.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            }
            else if (score < 31)//26-30
            {
                objeto = objects[Random.Range(0, 10)];
                objeto.GetComponent<Rigidbody2D>().gravityScale = 0.6f;
            }
            else if (score < 36)//31-35
            {
                objeto = objects[Random.Range(0, 12)];
                objeto.GetComponent<Rigidbody2D>().gravityScale = 0.7f;
            }
            else if (score >= 36)//36-...
            {
                objeto = objects[Random.Range(0, 13)];
                objeto.GetComponent<Rigidbody2D>().gravityScale = 1f;
            }

            Vector3 spawnPosition = new Vector3(Random.Range(-maxAncho, maxAncho), transform.position.y, -3.0f);
            Quaternion spawnRotation = Quaternion.identity;//0 no rotation
            Instantiate(objeto, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
       }

        //terminar el juego
        //destruir comida
        food = GameObject.FindGameObjectsWithTag("Food");
        for (int i = 0; i < food.Length; i++)
        {
            Destroy(food[i]);
        }
        //destruir peces
        fish = GameObject.FindGameObjectsWithTag("Fish");
        for (int i = 0; i < fish.Length; i++)
        {
            Destroy(fish[i]);
        }

        pauseButton.SetActive(false);
        audioSource.Stop();
        audioSource.clip = gameOver;
        audioSource.loop = false;
        audioSource.Play();
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        if (score > bestScore)
        {
            PlayerPrefs.SetInt("Score", score);
        }
        restartButton.SetActive(true);
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            audioSource.Pause();
            Time.timeScale = 0;
        }
        else if(Time.timeScale == 0)
        {
            audioSource.UnPause();
            Time.timeScale = 1;
        }
    }

    public void goHome()
    {
        SceneManager.LoadScene("Menu");
    }
}


