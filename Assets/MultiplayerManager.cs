using Normal.Realtime;
using UnityEngine;

public class MultiplayerManager : MonoBehaviour
{
    public GameObject player1Prefab; // Prefab para el primer jugador
    public GameObject player2Prefab; // Prefab para el segundo jugador
    private Realtime _realtime;

    void Start()
    {
        _realtime = GetComponent<Realtime>();
        _realtime.didConnectToRoom += OnDidConnectToRoom;
    }

    private void OnDidConnectToRoom(Realtime realtime)
    {
        int playerCount = realtime.clientID; // El ID del cliente actúa como el número de conexión
        print("Se conectó con el ID " + playerCount);

        GameObject playerInstance;
        if (playerCount == 0)
        {
            // Realtime.Instantiate para sincronizar el prefab en la red
            playerInstance = Realtime.Instantiate(player1Prefab.name, Vector3.zero, Quaternion.identity, new Realtime.InstantiateOptions { ownedByClient = true, preventOwnershipTakeover = true });
        }
        else if (playerCount == 1)
        {
            playerInstance = Realtime.Instantiate(player2Prefab.name, Vector3.zero, Quaternion.identity, new Realtime.InstantiateOptions { ownedByClient = true, preventOwnershipTakeover = true });
        }
        else
        {
            Debug.Log("Más de dos jugadores conectados, asignar otro rol o gestionar diferente");
            return;
        }

        // No es necesario asignar localAvatarPrefab ya que cada jugador se instancia y sincroniza automáticamente
    }
}
