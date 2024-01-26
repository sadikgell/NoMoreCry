using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float sprintSpeed = 10f;
    public float walkSpeed = 5f;
    public float sensitivity = 2f;
    
    private CharacterController characterController;
    private bool isSprinting = false;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        CheckSprintInput();

        Vector3 moveDirection = CalculateMoveDirection(horizontalInput, verticalInput);

        MovePlayer(moveDirection);

    }
    private void CheckSprintInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }

    private Vector3 CalculateMoveDirection(float horizontalInput, float verticalInput)
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        Vector3 moveDirection = horizontalInput * Camera.main.transform.right + verticalInput * cameraForward;

        if (moveDirection.magnitude > 1f)
        {
            moveDirection.Normalize();
        }

        return moveDirection;
    }

    private void MovePlayer(Vector3 moveDirection)
    {
        float speed = isSprinting ? sprintSpeed : walkSpeed;

        characterController.Move(moveDirection * speed * Time.deltaTime);

    }
}
