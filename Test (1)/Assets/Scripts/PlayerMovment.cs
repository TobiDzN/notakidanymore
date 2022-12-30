using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovment : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -19.61f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public bool ismoving;

    public static bool isInChaliceRange = false;

    [SerializeField]Animator animator;

    [SerializeField] Animator[] animators;
    [SerializeField] bool[] select;
    [SerializeField] GameObject[] characters;


    [SerializeField]
    private float cameraYOffset = 0.4f;
    [SerializeField]
    private float cameraZOffset = 0.4f;
    private Camera playerCamera;

    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    float rotationX = 0;

    private Alteruna.Avatar _avatar;

    void Start()
    {
        _avatar = GetComponent<Alteruna.Avatar>();

        if (!_avatar.IsMe)
            return;


        playerCamera = Camera.main;
        playerCamera.transform.position = new Vector3(transform.position.x, transform.position.y + cameraYOffset, transform.position.z + cameraZOffset);
        playerCamera.transform.SetParent(transform);


        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


        void Update()
    {
        if (!_avatar.IsMe)
            return;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

        
        characters[4].SetActive(false);
        if (select[0]||CharacterSelectScript.clicked&&CharacterSelectScript.whatClicked=="mage")
        {
            characters[0].gameObject.SetActive(true);
            animator = animators[0];
        }
        else if (select[1] || CharacterSelectScript.clicked && CharacterSelectScript.whatClicked == "td")
        {
            characters[1].gameObject.SetActive(true);
            animator = animators[1];
        }
        else if (select[2] || CharacterSelectScript.clicked && CharacterSelectScript.whatClicked == "tank")
        {
            characters[2].gameObject.SetActive(true);
            animator = animators[2];
        }
        else if(select[3] || CharacterSelectScript.clicked && CharacterSelectScript.whatClicked == "medic")
        {
            characters[3].gameObject.SetActive(true);
            animator = animators[3];
        }
        else if(CharacterSelectScript.clicked && CharacterSelectScript.whatClicked == "random")
        {
            select[UnityEngine.Random.Range(0, 4)] = true;
        }

        //if (Input.GetButtonDown("Jump") && isGrounded)
        //{
        //    Debug.Log("Jump!");
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        //}

        //IEnumerator waiter()
        //{
        //    gameObject.GetComponent<Animator>().enabled = false;
        //    gameObject.GetComponent<Animator>().enabled = true;
        //    animator.SetBool("IsIdle", false); ;
        //    animator.SetBool("PickingItem", true);

        //    yield return new WaitForSeconds(2);

        //    gameObject.GetComponent<Animator>().enabled = false;
        //    gameObject.GetComponent<Animator>().enabled = true;
        //    animator.SetBool("IsIdle", true); ;
        //    animator.SetBool("PickingItem", false);
        //}


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 18;
        }
        else
        {
            speed = 12;
        }

        if (z == 0 && x == 0)
        {
            ismoving = false;
        }
        else
        {
            ismoving = true;
        }

        if(isInChaliceRange)
        {
            animator.SetBool("IsIdle", true); ;
            animator.SetBool("PickingItem", true);
        }
        else
        {
            animator.SetBool("IsIdle", true); ;
            animator.SetBool("PickingItem", false);
        }


        //1 Right -1 Left
        if (z > 0)
        {
            if (x == 0)
            {
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", 1);
                animator.SetInteger("X", 0);
            }
            else if (x > 0)
            {
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", 1);
                animator.SetInteger("X", 1);
            }
            else if (x < 0)
            {
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", 1);
                animator.SetInteger("X", -1);
            }
        }
        else if (z < 0)
        {
            if (x == 0)
            {
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", -1);
                animator.SetInteger("X", 0);
            }
            else if (x > 0)
            {
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", -1);
                animator.SetInteger("X", 1);
            }
            else if (x < 0)
            {
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", -1);
                animator.SetInteger("X", -1);
            }
        }
        else if (x > 0)
        {
            if (z == 0)
            {
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", 0);
                animator.SetInteger("X", 1);
            }
            else if (z > 0)
            {
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", 1);
                animator.SetInteger("X", 1);
            }
            else if (z < 0)
            {
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", -1);
                animator.SetInteger("X", 1);
            }
        }
        else if (x < 0)
        {
            if (z == 0)
            {
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", 0);
                animator.SetInteger("X", -1);
            }
            else if (z > 0)
            {
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", 1);
                animator.SetInteger("X", -1);
            }
            else if (z < 0)
            {
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", -1);
                animator.SetInteger("X", -1);
            }
        }
        else if (z == 0 && x == 0)
        {
            animator.SetBool("IsIdle", true);
            animator.SetInteger("Z", 0);
            animator.SetInteger("X", 0);
        }

    }
}
