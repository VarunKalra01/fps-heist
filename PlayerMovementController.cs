using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private float jumpForce = 0;
    [SerializeField] private float jumpRaycastDistance = 0;   
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float crouchSpeed = 2f;
    [SerializeField] private Camera playerCamera; // Reference to the player camera

    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;
    private float originalHeight;
    private float originalSpeed;
    private float originalCameraYPosition;
    private bool isCrouching = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        originalHeight = capsuleCollider.height;
        originalSpeed = speed; // Initialize originalSpeed
        originalCameraYPosition = playerCamera.transform.localPosition.y; // Initialize original camera Y position
    }

    private void Update()
    {
        Jump();
        HandleCrouch();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed * Time.deltaTime;
        Vector3 newPosition = rb.position + rb.transform.TransformDirection(movement);
        rb.MovePosition(newPosition);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {        
        return Physics.Raycast(transform.position, Vector3.down, jumpRaycastDistance);
    }

    private void HandleCrouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isCrouching)
            {
                StandUp();
            }
            else
            {
                Crouch();
            }
        }
    }

    private void Crouch()
    {
        capsuleCollider.height = crouchHeight;
        speed = crouchSpeed;
        isCrouching = true;

        // Adjust camera position
        Vector3 cameraPosition = playerCamera.transform.localPosition;
        cameraPosition.y -= 0.5f;
        playerCamera.transform.localPosition = cameraPosition;
    }

    private void StandUp()
    {
        capsuleCollider.height = originalHeight;
        speed = originalSpeed;
        isCrouching = false;

        // Reset camera position
        Vector3 cameraPosition = playerCamera.transform.localPosition;
        cameraPosition.y = originalCameraYPosition;
        playerCamera.transform.localPosition = cameraPosition;
    }
}
