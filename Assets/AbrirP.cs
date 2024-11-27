using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirP : MonoBehaviour
{
    public float openAngle = 85f; // Ángulo al que se abrirá la puerta.
    public float duration = 1.5f; // Tiempo que tardará en abrirse.
    private Quaternion closedRotation; // Rotación cerrada.
    private Quaternion openRotation;   // Rotación abierta.
    public float elapsedTime = 0f;
    private bool isOpening = false;
    public GameObject puerta;
    public GameObject Luz;
    public Material ColorT;
    public coder[]  coderC;
    private bool prima = false;

    void Start()
    {
        closedRotation = puerta.transform.localRotation; // Guarda la rotación actual de la puerta.
        openRotation = closedRotation * Quaternion.Euler(0, openAngle, 0); // Define la rotación abierta.
        if(Luz != null) Luz.SetActive(false);
    }

    void Update()
    {
        if (!prima)
        foreach (coder c in coderC)
        {
            if (!c.isCode)
            {break;
            }
            else {OpenDoor(); prima = true; break;}
        }
        if (isOpening)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration); // Normaliza el tiempo entre 0 y 1.
            puerta.transform.localRotation = Quaternion.Slerp(closedRotation, openRotation, t); // Interpola entre las rotaciones.

            if (t >= 1f)
                isOpening = false; // Detiene el movimiento al completarse.
        }
    }

    public void OpenDoor()
    {
        if(ColorT != null) ColorT.color = Color.green;
        if (Luz != null) Luz.SetActive(true);
        isOpening = true;
    }
}
