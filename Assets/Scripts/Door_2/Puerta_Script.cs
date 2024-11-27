using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Puerta_Script : MonoBehaviour
{

    public float speed=4.0f;
    public float angle;

    public Vector3 dirreccion;
    
    public bool puedeAbrir;

    public bool abrir;

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag=="Player")
        {
            puedeAbrir=true;
        }
    }


    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag=="Player")
        {
            puedeAbrir=false;
        }
    }

    void Start()
    {
        angle= transform.eulerAngles.y;
    }

    void Update()
    {
        if(Mathf.Round(transform.eulerAngles.y)!= angle)
        {
            transform.Rotate(dirreccion*speed);

        }

        if(Input.GetButtonDown("Fire1") && puedeAbrir == true &&  abrir == false)  
        {
            angle =80;
            dirreccion=Vector3.up;
            abrir = true;

        }

        else if (Input.GetButtonDown("Fire1") && puedeAbrir == true &&  abrir == true)
        {
            angle =0;
            dirreccion=Vector3.down;
            abrir = false;

        }


        if(Input.GetKeyDown(KeyCode.F) && puedeAbrir == true &&  abrir == false)
        {
            angle =80;
            dirreccion=Vector3.up;
            abrir = true;


        }

        else if (Input.GetKeyDown(KeyCode.F) && puedeAbrir == true &&  abrir == true)
        {
            angle =0;
            dirreccion=Vector3.down;
            abrir = false;

        }
    }


}
