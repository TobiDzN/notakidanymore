using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CamController : NetworkBehaviour
{
    public GameObject cameraHolder;
    public Vector3 offset;

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            cameraHolder.SetActive(true);
        }
        else
        {
            cameraHolder.SetActive(false);
        }
    }

    public void Update()
    {
        cameraHolder.transform.position = transform.position + offset;
        
    }
}
