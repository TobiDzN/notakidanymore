using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaliceScript : MonoBehaviour
{
    bool entered = false;

    private PlayerMovment playerMovment;

    [SerializeField]GameObject UI,fullUI,EmtpyUI,Chalicego;
    [SerializeField] SphereCollider scollider;

    GameObject [] watersources;
    
    bool inCoasterRange = false;

    bool ChaliceAchievement = false;


    private void Awake()
    {
        playerMovment = FindObjectOfType<PlayerMovment>();
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
        scollider.GetComponent<Collider>().enabled = false;
        Chalicego.SetActive(false);
        playerMovment.setChalice(false);
    }
    public void isChaliceFull()
    {
        if (EmtpyUI.active == true)
        {
            EmtpyUI.gameObject.SetActive(false);
            fullUI.gameObject.SetActive(true);
            foreach (GameObject go in watersources)
            {
                go.GetComponent<SphereCollider>().enabled = false;
            }
            ChaliceAchievement = true;
        }
    }

    public void isInCoasterRange()
    {
        if (fullUI.active == true)
        {
            Chalicego.SetActive(true);
            transform.position = new Vector3(89.406189f, 13.7249889f, -116.198486f);
        }
    }    

    void Update()
    {
        if(entered&&Input.GetKeyDown(KeyCode.E))
        {
            playerMovment.setChalice(true);
            UI.SetActive(true);
            EmtpyUI.SetActive(true);
            StartCoroutine(waiter());
            watersources  = GameObject.FindGameObjectsWithTag("Water");
            foreach (GameObject go in watersources)
            {
                go.GetComponent<SphereCollider>().enabled = true;
            }
            entered = false;
        }
        else
        {
            playerMovment.setChalice(false);
        }

 
    }

    private void OnTriggerEnter(Collider other)
    {   
            entered = true;
    }

    private void OnTriggerExit(Collider other)
    {
            entered =false;
    }

}
