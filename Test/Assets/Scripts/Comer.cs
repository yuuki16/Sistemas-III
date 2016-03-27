using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Comer : MonoBehaviour 
{
    public Text puntaje;
    public Text vidas;
    public AudioClip eatFishClip;
    public AudioClip eatFoodClip;
    public float volume;

    AudioSource source;
    int puntos;
    int vida;
    int valor;
    void Start()
    {
        puntos = 0;
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
        }
        Destroy(other.gameObject);
    }

    void actPuntos()
    {
        puntaje.text = "Puntaje: " + puntos;
    }

    void actVidas()
    {
        vidas.text = "Vidas: " + vida;
    }
   
}
