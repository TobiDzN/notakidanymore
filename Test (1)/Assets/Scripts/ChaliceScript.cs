using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaliceScript : MonoBehaviour
{

    bool entered = false;


    void Update()
    {
        if(entered)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        entered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        entered=false;
    }

}
