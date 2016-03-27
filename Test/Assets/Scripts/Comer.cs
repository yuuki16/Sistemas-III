using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Comer : MonoBehaviour 
{
    public Text puntaje;
    public Text vidas;

    int puntos;
    int vida;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Food")
        {
            puntos = int.Parse(puntaje.text.Substring(9)) + 1;
            puntaje.text = "Puntaje: " + puntos;
        }
        else
        {
            vida = int.Parse(vidas.text .Substring(7)) - 1;
            vidas.text = "Vidas: " + vida;
        }
        Destroy(other.gameObject);
    }
}
