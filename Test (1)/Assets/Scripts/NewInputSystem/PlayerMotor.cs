using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool isCrouching;
    private bool isSprinting;
    private bool lerpCrouch;

    const float constBaseSpeed = 5f;
    public float speed = constBaseSpeed;
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;
    public float crouchTimer = 1;

    // Start is called before the first frame update
    void Start()
    {
        controller= GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

        if (lerpCrouch )
        {
            crouchTimer = Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;

            if(isCrouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);

            if (p > 1)
            {
                lerpCrouch= false;
                crouchTimer= 0f;
            }
        }
    }

    //receive the inputs for our InputManager and apply them to our character controller
    public void ProcessMove (Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(speed * Time.deltaTime * transform.TransformDirection(moveDirection));

        if(isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if(isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void Crouch()
    {
        isCrouching = !isCrouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }

    public void Sprint()
    {
        isSprinting= !isSprinting;
        if (isSprinting)
            speed = 8;
        else 
            speed = constBaseSpeed;
    }
}
