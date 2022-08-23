using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightHeadRemoveScript : MonoBehaviour
{
    public bool IsBeheaded = false;
    private Knightinteraction Knightinteraction;
    bool entered = false;
    public Animator animator;

    private void Awake()
    {
        Knightinteraction = FindObjectOfType<Knightinteraction>();
    }

    void Update()
    {
        if (entered)
        {
            if(Input.GetKeyDown(KeyCode.E)&&!IsBeheaded)
            {
                Knightinteraction.IsActivatable = true;
                animator.SetBool("WasBeheaded", true);
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
