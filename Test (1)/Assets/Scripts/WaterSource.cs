using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSource : MonoBehaviour
{
    bool entered = false;

    ChaliceScript chalice;

    private void Awake()
    {
        chalice = FindObjectOfType<ChaliceScript>();
    }

    void Update()
    {
        if(entered)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                chalice.isChaliceFull();
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        entered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        entered = false;
    }

}
