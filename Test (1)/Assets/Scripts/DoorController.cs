using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator animator = null;

    [SerializeField] private string doorstate = "idle";

    bool entered = false;

    public GameObject itext;

    public void DoorControl()
    {
        if (doorstate == "idle")
        {
            animator.SetBool("isClose", false);
            animator.SetBool("isOpen", false);
            animator.SetBool("isIdle", true);
        }
        else if (doorstate == "opening")
        {
            animator.SetBool("isClose", false);
            animator.SetBool("isOpen", true);
            animator.SetBool("isIdle", false);
        }
        else if (doorstate == "closing")
        {
            animator.SetBool("isClose", true);
            animator.SetBool("isOpen", false);
            animator.SetBool("isIdle", false);
        }
    }


    void Update()
    {

        if (entered == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (doorstate == "idle")
                {
                    doorstate = "opening";
                    DoorControl();
                }
                else if (doorstate == "opening")
                {
                    doorstate = "closing";
                    DoorControl();
                }
                else if (doorstate == "closing")
                {
                    doorstate = "opening";
                    DoorControl();
                }
            }
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        entered = true;
        itext.SetActive(true);
    }

    public void OnTriggerExit(Collider other)
    {
        entered = false;
        itext.SetActive(false);
    }


}
