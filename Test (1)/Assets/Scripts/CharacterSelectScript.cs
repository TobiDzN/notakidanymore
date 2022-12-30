using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectScript : MonoBehaviour
{

    public static bool clicked = false;
    public static string whatClicked;

    private void Awake()
    {
        
    }

    public void MedicButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        clicked = true;
        whatClicked = "medic";
    }
    public void TDButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        clicked = true;
        whatClicked = "td";
    }
    public void TankButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        clicked = true;
        whatClicked = "tank";
    }
    public void MageButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        clicked = true;
        whatClicked = "mage";
    }
    public void RandomButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        clicked = true;
        whatClicked = "random";
    }


}
