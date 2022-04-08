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

    Animator animator;


    // Update is called once per frame
    void Update()
    {
        animator = GetComponent<Animator>();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //if (Input.GetButtonDown("Jump") && isGrounded)
        //{
        //    Debug.Log("Jump!");
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
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


        //1 Right -1 Left
        if (z > 0)
        {
            if (x == 0)
            {
                gameObject.GetComponent<Animator>().enabled = false;
                gameObject.GetComponent<Animator>().enabled = true;
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", 1);
                animator.SetInteger("X", 0);
            }
            else if (x > 0)
            {
                gameObject.GetComponent<Animator>().enabled = false;
                gameObject.GetComponent<Animator>().enabled = true;
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", 1);
                animator.SetInteger("X", 1);
            }
            else if (x < 0)
            {
                gameObject.GetComponent<Animator>().enabled = false;
                gameObject.GetComponent<Animator>().enabled = true;
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", 1);
                animator.SetInteger("X", -1);
            }
        }
        else if (z < 0)
        {
            if (x == 0)
            {
                gameObject.GetComponent<Animator>().enabled = false;
                gameObject.GetComponent<Animator>().enabled = true;
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", -1);
                animator.SetInteger("X", 0);
            }
            else if (x > 0)
            {
                gameObject.GetComponent<Animator>().enabled = false;
                gameObject.GetComponent<Animator>().enabled = true;
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", -1);
                animator.SetInteger("X", 1);
            }
            else if (x < 0)
            {
                gameObject.GetComponent<Animator>().enabled = false;
                gameObject.GetComponent<Animator>().enabled = true;
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", -1);
                animator.SetInteger("X", -1);
            }
        }
        else if (x > 0)
        {
            if (z == 0)
            {
                gameObject.GetComponent<Animator>().enabled = false;
                gameObject.GetComponent<Animator>().enabled = true;
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", 0);
                animator.SetInteger("X", 1);
            }
            else if (z > 0)
            {
                gameObject.GetComponent<Animator>().enabled = false;
                gameObject.GetComponent<Animator>().enabled = true;
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", 1);
                animator.SetInteger("X", 1);
            }
            else if (z < 0)
            {
                gameObject.GetComponent<Animator>().enabled = false;
                gameObject.GetComponent<Animator>().enabled = true;
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", -1);
                animator.SetInteger("X", 1);
            }
        }
        else if (x < 0)
        {
            if (z == 0)
            {
                gameObject.GetComponent<Animator>().enabled = false;
                gameObject.GetComponent<Animator>().enabled = true;
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", 0);
                animator.SetInteger("X", -1);
            }
            else if (z > 0)
            {
                gameObject.GetComponent<Animator>().enabled = false;
                gameObject.GetComponent<Animator>().enabled = true;
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", 1);
                animator.SetInteger("X", -1);
            }
            else if (z < 0)
            {
                gameObject.GetComponent<Animator>().enabled = false;
                gameObject.GetComponent<Animator>().enabled = true;
                animator.SetBool("IsIdle", false); ;
                animator.SetInteger("Z", -1);
                animator.SetInteger("X", -1);
            }
        }
        else if (z == 0 && x == 0)
        {
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<Animator>().enabled = true;
            animator.SetBool("IsIdle", true);
            animator.SetInteger("Z", 0);
            animator.SetInteger("X", 0);
        }

    }
}
