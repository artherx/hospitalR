using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Look : MonoBehaviour
{

    public float  mouseSenstivy = 120f;

    //Sensibilidad de movimiento para la camara

    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {

        Cursor.lockState= CursorLockMode.Locked;
        //En el caso que maneje varias pantallas esto permite que el raton no se escape de la vista de unity


        
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*mouseSenstivy* Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*mouseSenstivy* Time.deltaTime;
        //Los Mouse X y Mouse Y son variables ya definidas para el manejo de mouse 

        xRotation -=mouseY;
        //Se pone  + o - para mirar si el sentido de movimiento bien se refiere al sentido de los ejes
        

        xRotation = Mathf.Clamp(xRotation,-90f,90f);

        //Limitar el movimiento de la rotacion

        transform.localRotation = Quaternion.Euler(xRotation,0,0);

        playerBody.Rotate(Vector3.up *mouseX);


    }
}
