using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posion : MonoBehaviour
{
    public Transform mano;
    private void OnTriggerStay(Collider other)
    {
        if (gameObject.transform.Find("agarre"))
        {
            // Obtener el Transform del hijo "agarre"
            Transform agarre = gameObject.transform.Find("agarre");

            if (agarre != null)
            {
                // Mueve el objeto padre a la posición de "mano" más la posición relativa de "agarre"
                gameObject.transform.position = mano.transform.position + (gameObject.transform.position-agarre.position);

                // Alinea la rotación con la de "mano"
                gameObject.transform.rotation = mano.transform.rotation;
            }
        }
    }
}
