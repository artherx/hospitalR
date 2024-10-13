using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mision : MonoBehaviour
{
    public GameObject cambio;
    private Renderer cambioRenderer; 
    private Color colorMemory;

    void Start()
    {
        // Obtener el componente Renderer del objeto 'cambio' y guardar su color original
        cambioRenderer = cambio.GetComponent<Renderer>();
        colorMemory = cambioRenderer.material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check to see if the tag on the collider is equal to "objM"
        if (other.tag == "objM")
        {
            // Cambiar la posición del objeto que entra en el trigger
            other.transform.position = new Vector3(4.3f, 1.3f, 3.7f);

            // Cambiar el color del objeto 'cambio'
            if (cambioRenderer != null)
            {
                // Cambiar el color a un rojo personalizado (RGB: 180, 20, 60) convirtiendo a valores entre 0 y 1
                cambioRenderer.material.color = new Color(180f / 255f, 20f / 255f, 60f / 255f);
            }
        }
        
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag=="objM"){
            // Restaurar el color original si es diferente al color guardado
            if (cambioRenderer != null && cambioRenderer.material.color != colorMemory)
            {
                cambioRenderer.material.color = colorMemory;
            }
        }
    }
}
