using UnityEngine;
using System.Collections;

public class MageryController : MonoBehaviour 
{
    public Camera camara;

    Animator animator;
    
    const int STATE_IDLE = 2;
    const int STATE_RUN = 1;
    
    string direccionActual = "right";
    int stateActual = STATE_IDLE;
    float maxAncho;
	// Use this for initialization
	void Start () 
	{
        if (camara == null)
        {
            camara = Camera.main;
        }
        animator = this.GetComponent<Animator>();
        //tamaño de la pantalla
        Vector3 esquinaSup = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 ancho = camara.ScreenToWorldPoint(esquinaSup);
        float MageryAncho = GetComponent<Renderer>().bounds.extents.x;
        maxAncho = ancho.x - MageryAncho;
    }
	void FixedUpdate () 
	{
       //mover a Magery
        Vector3 posicion = camara.ScreenToWorldPoint(Input.mousePosition);
        Vector3 posicionnueva = new Vector3(posicion.x, -3.66f, 0.0f);
        float ancho = Mathf.Clamp(posicionnueva.x, -maxAncho, maxAncho); //que no se pase del tamaño de la pantalla
        posicionnueva = new Vector3(ancho, posicionnueva.y, posicionnueva.y);
        
        //cambiar posición
        if (posicionnueva.x > transform.position.x)
        {
            changeDirection("right");
            changeState(STATE_RUN);
        }
        else if (posicionnueva.x < transform.position.x)
        {
            changeDirection("left");
            changeState(STATE_RUN);
        } else if (posicionnueva.x == transform.position.x) {
            changeState(STATE_IDLE);
        }

        GetComponent<Rigidbody2D>().MovePosition(posicionnueva);
    }

    void changeState(int pState)
    {
        if (stateActual == pState)
            return;

        switch(pState)
        {
            case STATE_IDLE:
                animator.SetInteger("State", STATE_IDLE);
                break;
            case STATE_RUN:
                animator.SetInteger("State", STATE_RUN);
                break;
        }

        stateActual = pState;
    }

    void changeDirection(string pDireccion)
    {
        if (direccionActual != pDireccion)
        {
            if (pDireccion == "right")
            {
                transform.Rotate(0, 180, 0);
                direccionActual = "right";
            }else if(pDireccion == "left")
            {
                transform.Rotate(0, -180, 0);
                direccionActual = "left";
            }
        }
    }
}
