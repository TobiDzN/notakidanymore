using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectScript : MonoBehaviour
{

    public static bool clicked = false;
    public static string whatClicked;
    [SerializeField] private GameObject characterScreen;
    [SerializeField] private GameObject loaderCanvas;
    [SerializeField] private Image loader;
    private void Awake()
    {
        
    }

    public async void LoadScene()
    {
        var scene = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        scene.allowSceneActivation = false;

        characterScreen.SetActive(false);
        loaderCanvas.SetActive(true);

        do
        {
            await Task.Delay(100);
            loader.fillAmount = scene.progress;

        } while (scene.progress < 0.9f);

        scene.allowSceneActivation = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MedicButton()
    {
        LoadScene();
        clicked = true;
        whatClicked = "medic";
    }
    public void TDButton()
    {
        LoadScene();
        clicked = true;
        whatClicked = "td";
    }
    public void TankButton()
    {
        LoadScene();
        clicked = true;
        whatClicked = "tank";
    }
    public void MageButton()
    {
        LoadScene();
        clicked = true;
        whatClicked = "mage";
    }
    public void RandomButton()
    {
        LoadScene();
        clicked = true;
        whatClicked = "random";
    }


}
