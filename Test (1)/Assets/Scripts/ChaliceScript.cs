using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChaliceScript : MonoBehaviour
{

    //variables
    bool entered = false;
    [SerializeField]GameObject UI,fullUI,EmtpyUI,Chalicego;
    [SerializeField] SphereCollider scollider;
    GameObject [] watersources;
    //bool inCoasterRange = false;
    bool ChaliceAchievement = false;
    [SerializeField] Vector3[] positions;
    

    private void Awake()
    {
        Vector3 temp = positions[UnityEngine.Random.Range(0, 4)];
        transform.position = temp;
    }

    //Waits 2 seconds and then vanishes Chalice
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
        scollider.GetComponent<Collider>().enabled = false;
        Chalicego.SetActive(false);
        PlayerMovment.isInChaliceRange = false;
    }

    //Fill up Chalice
    public void isChaliceFull()
    {
        if (EmtpyUI.activeSelf == true)
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

    //Place Chalice on Coaster
    public void isInCoasterRange()
    {
        if (fullUI.activeSelf == true)
        {
            Chalicego.SetActive(true);
            fullUI.gameObject.SetActive(false);
            transform.position = new Vector3(89.406189f, 13.7249889f, -116.198486f);
        }
    }    

    void Update()
    {


        //Pick up Chalice
        if (entered&&Input.GetKeyDown(KeyCode.E))
        {
            PlayerMovment.isInChaliceRange = true;
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
            PlayerMovment.isInChaliceRange = false;
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
