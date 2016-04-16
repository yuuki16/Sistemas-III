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
            if (other.gameObject.tag == "Food")
            {
                vida = vida - 1;
                actVidas();
            }
        }
        
        Destroy(other.gameObject);
    }

    void actVidas()
    {
        vidas.text = "Vidas: " + vida;
    }
}
