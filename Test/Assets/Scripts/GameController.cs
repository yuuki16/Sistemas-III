using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
    public Camera camara;
    public GameObject[] objects;
    public Text vidas;
    public GameObject gameOverText;
    public GameObject restartButton;

    private float maxAncho;
    private GameObject[] food;
    private GameObject[] fish;

    int vida = 3;
	// Use this for initialization
	void Start () 
	{
        if (camara == null)
        {
            camara = Camera.main;
        }
        //establecer tamaño pantalla
        Vector3 esquinaSup = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 ancho = camara.ScreenToWorldPoint(esquinaSup);
        float bentoAncho = objects[0].GetComponent<Renderer>().bounds.extents.x;
        maxAncho = ancho.x - bentoAncho;
        StartCoroutine(Spawn());
    }
	

	void FixedUpdate () 
	{
        vida = int.Parse(vidas.text.Substring(7));
     }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.0f);//tiempo de espera para spawnear

        while (vida > 0)
        {
            GameObject objeto = objects[Random.Range(0, objects.Length)];
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

        //yield return new WaitForSeconds(2.0f);
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        restartButton.SetActive(true);
    }
}


