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

    bool isInChaliceRange = false;

    [SerializeField]Animator animator;

    [SerializeField] Animator[] animators;
    [SerializeField] bool[] select;
    [SerializeField] GameObject[] characters;
    

    public bool setChalice(bool status)
    {
        return isInChaliceRange=status;
    }
    
    void Update()
    {
        //animator = GetComponent<Animator>();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        characters[4].SetActive(false);
        if (select[0])
        {
            characters[0].gameObject.SetActive(true);
            animator = animators[0];
        }
        else if (select[1])
        {
            characters[1].gameObject.SetActive(true);
            animator = animators[1];
        }
        else if (select[2])
        {
            characters[2].gameObject.SetActive(true);
            animator = animators[2];
        }
        else if(select[3])
        {
            characters[3].gameObject.SetActive(true);
            animator = animators[3];
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
