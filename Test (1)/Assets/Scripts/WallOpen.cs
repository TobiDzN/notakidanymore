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

    public ParticleSystem dust;

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
        dust.Play();
        yield return new WaitForSeconds(5);
        dust.Stop();
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
                        FindObjectOfType<AudioManager>().Play("WallOpen");
                        doorstate = "opening";
                        DoorControl();
                    }
                    else if (doorstate == "opening")
                    {
                        FindObjectOfType<AudioManager>().Play("WallClose");
                        doorstate = "closing";
                        DoorControl();
                    }
                    else if (doorstate == "closing")
                    {
                        FindObjectOfType<AudioManager>().Play("WallOpen");
                        doorstate = "opening";
                        DoorControl();
                    }
                }
            }
        }
    }


}
