using System.Collections;
using UnityEngine;

public class Luces : MonoBehaviour
{
    public Light Foco; 
    private bool activacion = true; 

    void Start()
    {
        StartCoroutine(CicloLuces());
    }

    IEnumerator CicloLuces()
    {
        Foco.enabled = true;
        yield return new WaitForSeconds(10f);

        while (true)
        {
            activacion = !activacion; 
            Foco.enabled = activacion; 

            float tiempo = Random.Range(10f, 20f); //  tiempo aleatorio entre 10 y 20 segundos
            yield return new WaitForSeconds(tiempo);
        }
    }
}
