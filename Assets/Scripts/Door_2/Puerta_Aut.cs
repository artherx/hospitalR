using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta_Aut : MonoBehaviour
{
    
    //Velocidad de la puerta
    float speed=4.0f;
    //Angulo de giro de la puerta
    float giro=90.0f;

    //Posicion inicial de la puerta
    private Vector3 Posicion_Inicial;

    //Posicion final de la puerta
    private Vector3 Posicion_Final;
    
    //Variable que indique si la puerta esta abierta
    private bool open;

    //Variable que indica si el personaje esta en colision con el collider con la puerta
    private bool enter;

    //Puerta datos de guardado
    public GameObject door ;

     private GUIStyle estiloPersonalizado;


    // AudioSource asignado en el objeto door
    private AudioSource audioSource;

    public AudioClip open_door;

    public AudioClip close_door;



     private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que ha entrado en colision es el player
        if (other.gameObject.tag == "Player")
        {
            // Colocamos la variable enter a true
            enter = true;
        }
    }

    // Trigger que detecta cuando un objeto ha salido de colision con el objeto que tiene asignado este script
    private void OnTriggerExit(Collider other)
    {
        // Si el objeto que ha salido de colision es el player
        if (other.gameObject.tag == "Player")
        {
            // Colocamos la variable enter a false
            enter = false;
        }
    }





    

    void Start()
    {
        //Se guarda los datos de posicion inicial de la visagra
        Posicion_Inicial=transform.eulerAngles;

        //Se guarda la posicion final de puerta
        Posicion_Final= new Vector3(Posicion_Inicial.x,Posicion_Inicial.y+giro,Posicion_Inicial.z);

       // Hacemos referencia al audiosource asignado en la raiz (door)
        audioSource = door.GetComponent<AudioSource>();



    }

    void Update()
    {

        
        if(open==true)
        {
           transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, Posicion_Final,   Time.deltaTime * speed);

           //Vector3.Slerp(start, end, t):
           //Star inicio de posicion
           //End fin de posicion
           //t tiempo que tarda en llegar de un punto a otro

        }
        else 
        {
          transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, Posicion_Inicial,   Time.deltaTime * speed);

        }


        if (enter==true)
        {
            // en caso de que sea cierto la variable open tomara el valor de true
            // con esto conseguiremos que cuando unity llame a la funcion update
            // entre en el caso de abrir puerta
            open = !open;

            if (open==true)
            {
                // Si se se va a abrir la puerta se asigna la velocidad de movimiento de
                //apertura de la puerta
                speed = 4.0f;

               // Se asigna el clip de audio al audiosource
                audioSource.clip = open_door;
                // Se reproduce el sonido
                audioSource.Play();
            }
               
                   else
            {
                // Si se se va a cerrar la puerta se asigna la velocidad de movimiento de
                //cierre de la puerta
                speed = 10.0f;
              

               // Se asigna el clip de audio al audiosource
                audioSource.clip = close_door;
                // Se reproduce el sonido
                audioSource.Play();
            }
            
            }
        
}
}
