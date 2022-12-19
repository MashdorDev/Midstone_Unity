using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Character Controller
    public CharacterController controller; // Publicly define our character controller

    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 1f;
    public Transform groundCheck; // Check if we are on the ground
    public float groundDistance = 0.18f;
    public LayerMask groundMask; // Set a field for ground layer
    float speed;

    Vector3 velocity;
    public bool grounded;

    // Stamina Bar
    public int maxStamina = 100;
    public int currentStamina = 100;

    public StaminaBar staminaBar;

    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);
    }

    private void Update()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        Debug.Log("Player Position: " + groundCheck.position);
        Debug.Log("Player Velocity: " + velocity);

        if (grounded && velocity.y < 0) // constant negative y velocity when grounded to provide realistic downward movement on slopes
        {
            velocity.y = -2f;
            Debug.Log("Grounded");
        }

        if (Input.GetKey(KeyCode.LeftShift)) // adjust move speed
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }

        float x = Input.GetAxis("Horizontal"); // Define  horizontal" axis
        float z = Input.GetAxis("Vertical"); // Define vertical" axis

        Vector3 move = transform.right * x + transform.forward * z; // Define the move vector

        controller.Move(move * speed * Time.deltaTime); // Move function

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime; // set Vertical velocity bound to gravity

        controller.Move(velocity * Time.deltaTime); // Apply Vertical velocity to character controller

        // Player Stamina

        // Test stamina bar -> working
        // pseudo
        // if enemy gets close -> getNumb -> implement trigger box for enemies
        // if currentStamina < 0 -> gameover
        if (Input.GetKeyDown(KeyCode.K))
        {
            GetNumb(10);
        }

        void GetNumb(int stun)
        {
            currentStamina -= stun;
            
            if(currentStamina < 0) currentStamina = 0;

            staminaBar.SetStamina(currentStamina);
        }
    }
}