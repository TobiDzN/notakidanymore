using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOpen : MonoBehaviour
{
    [SerializeField] private Animator animator = null;

    [SerializeField] private string doorstate = "idle";

    public GameObject itext;

    public Light torch;

    public LayerMask interactablelayermask;

    bool entered = false;

    bool isClickable = true;

    


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


    IEnumerator waiter()
    {
        isClickable = false;
        yield return new WaitForSeconds(5);
        isClickable = true;
    }


    void Update()
    {
        RaycastHit hit;



        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 4, interactablelayermask))
        {
            torch.GetComponent<Light>().enabled = true;
            entered = true;
            itext.SetActive(true);
        }
        else
        {
            torch.GetComponent<Light>().enabled = false;
            entered = false;
            itext.SetActive(false);
        }


        if (isClickable)
        {
            if (entered == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    StartCoroutine(waiter());
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
    }


}
