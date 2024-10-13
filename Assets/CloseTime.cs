using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTime : MonoBehaviour
{
    public float timeLimit = 120f; // Tiempo límite en segundos (120 segundos)
    public float timeLimi123; // Tiempo límite en segundos (120 segundos)

    void Update()
    {
        timeLimi123 = Time.time;
        // Verifica si el tiempo transcurrido ha superado el límite
        if (Time.time >= timeLimit)
        {
            CloseGame();
        }
    }

    void CloseGame()
    {
        // Cierra el juego
        Debug.Log("Tiempo límite alcanzado. Cerrando el juego...");

        // En el Editor de Unity, Application.Quit() no funcionará, así que usa esta condición para detener la simulación
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
