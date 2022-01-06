using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    public Light Light;
    private bool isActive = true;

    void Update()
    {
        
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.F))
        {
            Light.GetComponent<Light>().enabled = isActive;
            isActive = !isActive;
            Debug.Log("Activate / Deactivate Flashlight");
        }
    }
}
