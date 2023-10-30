using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


public class CharacterSpawner : NetworkBehaviour
{

    [SerializeField] public GameObject playerPrefab;
    private bool hasSpawnedPlayer = false;

    private void OnServerInitialized()
    {
        if(!hasSpawnedPlayer)
        {
            SpawnPlayer();
            hasSpawnedPlayer = true;
        }
    }

    private void SpawnPlayer()
    {
        GameObject player = Instantiate(playerPrefab);
        NetworkObject playerNetworkObject = player.GetComponent<NetworkObject>();
        playerNetworkObject.SpawnWithOwnership(OwnerClientId);

    }


}
