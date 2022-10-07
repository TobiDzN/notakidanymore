using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaliceCoaster : MonoBehaviour
{
    bool entered = false;

    ChaliceScript chalicescript;

    private void Awake()
    {
        chalicescript = FindObjectOfType<ChaliceScript>();
    }

    void Update()
    {
        if(entered&&Input.GetKeyDown(KeyCode.E))
        {
            chalicescript.isInCoasterRange();
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
