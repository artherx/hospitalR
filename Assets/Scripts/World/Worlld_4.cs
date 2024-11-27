using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Worlld_4 : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que ha entrado en colision es el player
        if (other.gameObject.tag == "Player")
        {

        SceneManager.LoadScene("Escena_4");
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
