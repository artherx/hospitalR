using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class World_1 : MonoBehaviour
{


    private bool confirmacion;


    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que ha entrado en colision es el player
        if (other.gameObject.tag == "Player")
        {

        SceneManager.LoadScene("Escena_1");
        }
    }



    void Start()
    {
        
    }

    void Update()
    {


        
    }
}



