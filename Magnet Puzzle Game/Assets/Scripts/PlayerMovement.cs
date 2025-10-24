using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float normalspeed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public CharacterController controller;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Creates a small sphere for ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;        
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * normalspeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (isGrounded == false)
        {
            controller.stepOffset = 0;
        }
        else if (isGrounded == true) 
        {
            StartCoroutine(StepCD());

            controller.stepOffset = 0.6f;
        }

    }

    IEnumerator StepCD()
    {
        yield return new WaitForSeconds(2f);

    }


}
