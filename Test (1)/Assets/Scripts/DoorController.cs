using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class DoorController : AttributesSync
{
    [SerializeField] private Animator animator = null;

    [SynchronizableField] private string doorstate = "idle";

    bool entered = false;

    public GameObject itext;

    [SynchronizableMethod]
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

    [SynchronizableMethod]
    void Update()
    {
        BroadcastRemoteMethod("doorUpdate");
    }

    [SynchronizableMethod]
    void doorUpdate()
    {
        if (entered == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (doorstate == "idle")
                {
                    doorstate = "opening";
                    BroadcastRemoteMethod("DoorControl");
                }
                else if (doorstate == "opening")
                {
                    doorstate = "closing";
                    BroadcastRemoteMethod("DoorControl");
                }
                else if (doorstate == "closing")
                {
                    doorstate = "opening";
                    BroadcastRemoteMethod("DoorControl");
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
