using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Link: https://www.youtube.com/watch?v=f473C43s8nE&t=244s 

public class PlayerCam : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 3.0F;
    private float rotateSpeed = 3.0F;

    public float sensX;
    public float sensY;

    public Transform orientation;
    public Transform player;

    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        // controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f); // cant look up/down too far

        // rotate cam orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        // used chatgpt for this
        player.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
