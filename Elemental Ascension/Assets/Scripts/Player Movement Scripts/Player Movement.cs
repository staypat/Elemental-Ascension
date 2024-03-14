using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Link: https://www.youtube.com/watch?v=f473C43s8nE&t=244s 

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public float dashForce;
    public float dashCooldown = 2f;
    private float dashTime = 0.1f;
    public Image dashCooldownBox;
    public TMP_Text cooldownTextDash;
    // public float dashCooldown;
    [HideInInspector] public bool readyToJump;
    [HideInInspector] public bool isDashing = false;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode dashKey = KeyCode.LeftShift;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    [HideInInspector] public bool grounded;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    [Header("Dash Clips")]
    public AudioClip[] clips;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
        dashCooldownBox.fillAmount = 1f;
        cooldownTextDash.gameObject.SetActive(false);
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();
            Debug.Log("Jumped");

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        // when to dash
        if (Input.GetKeyDown(dashKey))
        {
            StartCoroutine(Dash());
        }


    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }

    private IEnumerator Dash()
    {
        if (!isDashing)
        {
            isDashing = true;
            cooldownTextDash.gameObject.SetActive(true);
            cooldownTextDash.text = dashCooldown.ToString();

            // play dash sfx
            this.GetComponent<AudioSource>().PlayOneShot(clips[Random.Range(0,3)], 0.7f);

            // Getting the camera's forward and right vectors
            Vector3 cameraForward = Camera.main.transform.forward;
            cameraForward.y = 0;
            cameraForward.Normalize();
            Vector3 cameraRight = Camera.main.transform.right;
            cameraRight.y = 0;
            cameraRight.Normalize();

            // Dash in the direction of the camera
            Vector3 dashDirection = (cameraRight * Input.GetAxisRaw("Horizontal") + cameraForward * Input.GetAxisRaw("Vertical")).normalized; // Dash in the direction of movement
            float startTime = Time.time;

            // Raycast to check for collision
            RaycastHit hit;
            if (Physics.Raycast(transform.position, dashDirection, out hit, dashTime * dashForce, ~whatIsGround))
            {
                // There is an obstacle in the dash direction, adjust the dash time accordingly
                dashTime = hit.distance / dashForce;
            }

            while (Time.time < startTime + dashTime)
            {
                rb.AddForce(dashDirection * dashForce, ForceMode.Impulse);
                yield return null; // Wait for the next frame
            }
            while (dashCooldownBox.fillAmount > 0)
            {
                dashCooldownBox.fillAmount -= Time.deltaTime / dashCooldown;
                cooldownTextDash.text = (dashCooldownBox.fillAmount * dashCooldown).ToString("F1");
                yield return null;
            }
            dashCooldownBox.fillAmount = 1f;
            cooldownTextDash.gameObject.SetActive(false);
            isDashing = false;
        }
    }
}