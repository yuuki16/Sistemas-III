using UnityEngine;
using System.Collections;

public class MageryController : MonoBehaviour 
{
    public Camera camara;
    public float velocidad = 2.0f;
    public AccelerationEvent accEvent;

    Animator animator;
    const int STATE_IDLE = 2;
    const int STATE_RUN = 1;
    string direccionActual = "right";
    int stateActual = STATE_IDLE;
    float maxAncho, x;
    Vector3 position, defaultAcc, pantalla;
    Rigidbody2D rb;

    void Start () 
	{
        if (camara == null)
        {
            camara = Camera.main;
        }
        animator = this.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        defaultAcc = new Vector3(Input.acceleration.x, -3.66f, -3.0f);
        //tamaño de la pantalla
        pantalla = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 ancho = camara.ScreenToWorldPoint(pantalla);
        float MageryAncho = GetComponent<Renderer>().bounds.extents.x;
        maxAncho = ancho.x - MageryAncho;
    }
	void Update () 
	{
        Vector3 acceleration = new Vector3(Input.acceleration.x, -3.66f, -3.0f);
        acceleration -= defaultAcc;
        if (Time.timeScale == 1)
        {
            //si es una fuerza mayor
            if (acceleration.sqrMagnitude >= 0.03f)
            {
                Vector3 newPosition = transform.position + acceleration;
                //que no sobrepase el ancho de la pantalla
                if (newPosition.x < maxAncho && newPosition.x > -maxAncho)
                {
                    rb.AddForce(transform.forward * Time.deltaTime);
                    accelerometerMove(transform.position.x, newPosition.x);
                    transform.position = newPosition;
                }
            }
            else
            {
                changeState(STATE_IDLE);
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
        changeState(STATE_RUN);
        changeDirection("left");
    }

    void moveRight()
    {
        changeState(STATE_RUN);
        changeDirection("right");
    }
    
    void accelerometerMove(float oldX, float newX)
    {
        if (newX < oldX) //left
        {
            moveLeft();
        }
        else if(newX > oldX) //right
        {
            moveRight();
        }
    }
}
