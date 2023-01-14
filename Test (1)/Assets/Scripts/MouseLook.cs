using UnityEngine;


public class MouseLook : MonoBehaviour
{

    [SerializeField] public float lookSpeed = 2f;

    public Transform playerBody;
    float xRotation = 0f;
    public float lookXLimit = 45.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        xRotation += -Input.GetAxis("Mouse Y") * lookSpeed;
        xRotation = Mathf.Clamp(xRotation, -lookXLimit, lookXLimit);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        //playerBody.Rotate(Vector3.up * mouseX);
    }
}
