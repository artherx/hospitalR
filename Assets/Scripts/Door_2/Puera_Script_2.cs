using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Puerta_Script_2 : MonoBehaviour
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

  private void OnGUI()
// es el método OnGUI() que Unity ejecuta en cada frame. 
//Se utiliza para renderizar elementos de la interfaz gráfica.
{
    // Si el player ha entrado en contacto con el collider de la puerta
    if (enter==true)
    {

        estiloPersonalizado = new GUIStyle();

        // Cambiamos el color del texto
        estiloPersonalizado.normal.textColor = Color.red; // Cambia el color a rojo, puedes usar otros colores o `new Color(r, g, b, a)`.
        //estiloPersonalizado.normal.textColor = new Color(0.5f, 0.2f, 0.8f, 1.0f); // Un color púrpura.

        // Cambiamos el tipo de letra
        estiloPersonalizado.font = (Font)Resources.Load("Times New Roman"); // Reemplaza "NombreDeLaFuente" por el nombre de tu fuente (sin extensión) y asegúrate de que esté en la carpeta Resources.
        // Cambiamos el tamaño de la fuente
        estiloPersonalizado.fontSize = 20; // Puedes ajustar el tamaño de la fuente según tus necesidades.
        // Se muestra el mensaje de interaccion
        GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 30), "Presione 'F' Para abrir la puerta", estiloPersonalizado);
        //x: La posición horizontal (en píxeles) desde la esquina superior izquierda de la pantalla.
        //y: La posición vertical (en píxeles) desde la esquina superior izquierda de la pantalla.
        //width: El ancho del rectángulo que contendrá el texto.
        //height: La altura del rectángulo que contendr
    }
   }



    

    void Start()
    {
        //Se guarda los datos de posicion inicial de la visagra
        Posicion_Inicial=transform.eulerAngles;

        //Se guarda la posicion final de puerta
        Posicion_Final= new Vector3(Posicion_Inicial.x,Posicion_Inicial.y+giro,Posicion_Inicial.z);




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


        if (Input.GetKeyDown("f") && enter==true)
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
               
            }
            else
            {
                // Si se se va a cerrar la puerta se asigna la velocidad de movimiento de
                //cierre de la puerta
                speed = 10.0f;
              
            }




    }
       
    }
}