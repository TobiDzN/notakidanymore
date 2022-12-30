using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectScript : MonoBehaviour
{
    private PlayerMovment playerMovment;

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(5);
    }


    public void MedicButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(waiter());
        playerMovment = GameObject.Find("First Person Player(Clone)").GetComponent<PlayerMovment>();
        playerMovment.setSelect(3);
    }
    public void TDButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(waiter());
        playerMovment = GameObject.Find("First Person Player(Clone)").GetComponent<PlayerMovment>();
        playerMovment.setSelect(1);
    }
    public void TankButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(waiter());
        playerMovment = GameObject.Find("First Person Player(Clone)").GetComponent<PlayerMovment>();
        playerMovment.setSelect(2);
    }
    public void MageButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(waiter());
        playerMovment = GameObject.Find("First Person Player(Clone)").GetComponent<PlayerMovment>();
        playerMovment.setSelect(0);
    }
    public void RandomButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(waiter());
        playerMovment = GameObject.Find("First Person Player(Clone)").GetComponent<PlayerMovment>();
        playerMovment.setSelect(UnityEngine.Random.Range(0,4));
    }
}
