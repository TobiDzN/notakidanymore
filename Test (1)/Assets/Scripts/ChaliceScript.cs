using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaliceScript : MonoBehaviour
{
    bool entered = false;

    private PlayerMovment playerMovment;

    [SerializeField]GameObject UI,fullUI,EmtpyUI,Chalice;
    [SerializeField] Component collider;

    private void Awake()
    {
        playerMovment = FindObjectOfType<PlayerMovment>();
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
        collider.gameObject.SetActive(false);
    }

    void Update()
    {
        if(entered&&Input.GetKeyDown(KeyCode.E))
        {
            playerMovment.setChalice(true);
            UI.SetActive(true);
            EmtpyUI.SetActive(true);
            Chalice.SetActive(false);       
            StartCoroutine(waiter());
            
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
        entered=false;
    }

}
