using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niñas : MonoBehaviour
{ 

     int valor =0;

    private AudioSource audioSource;

    public AudioClip Girls;

    public GameObject Radio ;





     private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que ha entrado en colision es el player
        if (other.gameObject.tag == "Player")
        {

            valor++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       audioSource = Radio.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (valor==1)
        {
            // Se asigna el clip de audio al audiosource
                audioSource.clip = Girls;
                // Se reproduce el sonido
                audioSource.Play();

                valor++;
        }
        
    }
}
