using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knightinteraction : MonoBehaviour
{
    public bool IsActivatable=false;
    public Animator animator;
    bool entered =false;

    void Update()
    {
        if (IsActivatable)
        {
            if (entered && Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool("IsActivatable", true);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        entered = true; 
    }

    private void OnTriggerExit(Collider other)
    {
        entered = false;
    }
}
