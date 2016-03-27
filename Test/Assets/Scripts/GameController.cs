using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
    public Camera camara;
    public GameObject bentoBox;
    public Text vidas;
    private float maxAncho;

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
        float bentoAncho = bentoBox.GetComponent<Renderer>().bounds.extents.x;
        maxAncho = ancho.x - bentoAncho;
        StartCoroutine(Spawn());
    }
	
	// Update is called once per frame
	void FixedUpdate () 
	{
        vida = int.Parse(vidas.text.Substring(7));
     }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.0f);//tiempo de espera para spawnear
        while (vida > 0)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-maxAncho, maxAncho), transform.position.y, -3.0f);
            Quaternion spawnRotation = Quaternion.identity;//0 no rotation
            Instantiate(bentoBox, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
       }
    }
}


