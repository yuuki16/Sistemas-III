using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour 
{

    public Text vidas;
    public int vida;

    void OnTriggerEnter2D(Collider2D other)
    {
        vida = int.Parse(vidas.text.Substring(7));

        if (vida <= 0)
        {
            vidas.text = "Vidas: 0";
        }
        else
        {
            vida = vida - 1;
            vidas.text = "Vidas: " + vida;
        }
        
        Destroy(other.gameObject);
    }
}
