using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour 
{
    public float velocidad = 0.5f;
	// Use this for initialization
	void Start () 
	{
        scroll();
	}
	
	// Update is called once per frame
	void Update () 
	{
        scroll();
	}

    void scroll()
    {

        Vector2 offset = new Vector2(Time.time * velocidad, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
