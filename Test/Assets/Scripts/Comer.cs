using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Comer : MonoBehaviour 
{
    public Text score;
    public Text vidas;
    public AudioClip eatFishClip;
    public AudioClip eatFoodClip;
    public float volume;
    public Image[] Hearts;

    GameObject[] food;
    GameObject[] fish;
    AudioSource source;
    int puntos;
    int vida;
    int valor;
    void Start()
    {
        puntos = int.Parse(score.text);
        valor = 1;
        actPuntos();
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Food")
        {
            source.PlayOneShot(eatFoodClip, volume);
            puntos += valor;
            actPuntos();
        }
        else if(other.gameObject.tag == "Fish")
        {
            source.PlayOneShot(eatFishClip, volume);
            vida = int.Parse(vidas.text.Substring(7)) - 1;
            actVidas();
            if (vida == 0)
            {
                Hearts[0].gameObject.SetActive(false);
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
            }
            else if(vida == 2)
            {
                Hearts[2].gameObject.SetActive(false);
            }
            else if(vida == 1)
            {
                Hearts[1].gameObject.SetActive(false);
            }
        }
        Destroy(other.gameObject);
    }

    void actPuntos()
    {
        score.text = puntos.ToString();
    }

    void actVidas()
    {
        vidas.text = "Vidas: " + vida;
        
    }
   
}
