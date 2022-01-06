using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    public Light Light;
    private bool isActive = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Light.GetComponent<Light>().enabled = isActive;
            isActive = !isActive;
        }
    }
}
