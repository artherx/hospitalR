using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World_3 : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que ha entrado en colision es el player
        if (other.gameObject.tag == "Player")
        {
        SceneManager.LoadScene("Escena_3");
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
