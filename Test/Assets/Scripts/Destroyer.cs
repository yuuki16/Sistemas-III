using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour 
{

    public Text vidas;
    public int vida;
    public Image[] Hearts;

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
        if (vida == 2)
        {
            Hearts[2].gameObject.SetActive(false);
        }
        else if (vida == 1)
        {
            Hearts[1].gameObject.SetActive(false);
        }
        else if (vida == 0)
        {
            Hearts[0].gameObject.SetActive(false);
        }
    }
}
