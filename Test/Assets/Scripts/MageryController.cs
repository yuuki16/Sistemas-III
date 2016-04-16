using UnityEngine;
using System.Collections;

public class MageryController : MonoBehaviour 
{
    public Camera camara;
    public float velocidad = 1.0f;

    Animator animator;
    const int STATE_IDLE = 2;
    const int STATE_RUN = 1;
    string direccionActual = "right";
    int stateActual = STATE_IDLE;
    float maxAncho, x;
    Vector3 position;

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
	void Update () 
	{
        float rounded = Mathf.Round((transform.position.x) * 10.0f) / 10.0f;
        if (Time.timeScale == 1)
        {

            accelerometerMove(rounded);
            position = Vector3.zero;
            position.y = -3.66f;
            position.z = -3.0f;
            position.x = x * velocidad;

            if (position.x != transform.position.x)
            {
                transform.position = position;

            }
        }
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

    void moveLeft()
    {
        //rb.velocity = new Vector2(velocidad, 0);
        changeState(STATE_RUN);
        changeDirection("left");
    }

    void moveRight()
    {
        //rb.velocity = new Vector2(-velocidad, 0);
        changeState(STATE_RUN);
        changeDirection("right");
    }
    
    void accelerometerMove(float posicionvieja)
    {
        x = Input.acceleration.x;
        float rounded = Mathf.Round((x* velocidad) * 10.0f) / 10.0f;
        //Debug.Log("Vieja: "+posicionvieja+". Nueva: "+rounded);
        if (rounded < posicionvieja) //left
        {
            moveLeft();
        }
        else if(rounded > posicionvieja) //right
        {
            moveRight();
        }
        else if(rounded == posicionvieja)
        {
            changeState(STATE_IDLE);
        }

    }
}
