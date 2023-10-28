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
        SetSkinChoice("medic"); // Pass the chosen skin as a parameter
    }

    public void TDButton()
    {
        SetSkinChoice("td"); // Pass the chosen skin as a parameter
    }

    public void TankButton()
    {
        SetSkinChoice("tank"); // Pass the chosen skin as a parameter
    }

    public void MageButton()
    {
        SetSkinChoice("mage"); // Pass the chosen skin as a parameter
    }

    public void RandomButton()
    {
        SetSkinChoice("random"); // Pass the chosen skin as a parameter
    }

    private void SetSkinChoice(string skinChoice)
    {
        LoadScene();
        clicked = true;
        whatClicked = skinChoice;
    }



}
