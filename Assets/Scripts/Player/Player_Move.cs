using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 10.0f;

    private float gravity = -9.81f;

    private Vector3 velocity;
    
    //ubicacion de pie    
    public Transform feet;

    //radio del tamaño de esfera de contacto
    public float shareRadius = 0.3f ;
    
    //Es una mascara para identificar que es un suelo y no
    public LayerMask groundMask;

    bool isGrounded;

    private float jumpHeight=3f;

    void Start()
    {
        // Inicializaciones si es necesario
    }

    void Update()
    {

        isGrounded =Physics.CheckSphere(feet.position,shareRadius,groundMask);

        if(isGrounded==true && velocity.y <0){
            velocity.y =-2f;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true){
            velocity.y = Mathf.Sqrt(-2 * gravity * jumpHeight);
            Debug.Log("Salto");

        }

        float x = 0f;
        float z = 0f;

        // Capturar el movimiento en los ejes X y Z
        if (Input.GetKey(KeyCode.W))
        {
            z += 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            z -= 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x -= 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            x += 1f;
        }

        // Crear el vector de movimiento usando las direcciones calculadas
        Vector3 move = transform.right * x + transform.forward * z;

        //Asignacion de la gravedad a vector

        velocity.y+=gravity*Time.deltaTime;

        // Mover el personaje
        characterController.Move(move.normalized * speed * Time.deltaTime);

        //Gravedad con el characteController

        characterController.Move(velocity*Time.deltaTime);




    }
}

