using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] Button playBT;
    [SerializeField] Button optionsBT;
    [SerializeField] Button quitBT;

    public void Awake()
    {
        playBT.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene("PresistentScene",LoadSceneMode.Additive);
        });

        optionsBT.onClick.AddListener(() =>
        {

        });

        quitBT.onClick.AddListener(() =>
        {

        });
    }

}
