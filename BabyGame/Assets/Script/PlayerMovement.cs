using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /* De�i�ken a��klamalar�:
     * sprintSpeed: Ko�arkenki h�z�m�z.
     * walkSpeed: Y�r�rkenki h�z�m�z.
     * sensitivity: Fare hassasiyeti.
     * jumpHeight: Z�plama y�ksekli�i. Artt�rd�k�a z�plama oran� art�yor.
     * gravityValue: Yer�ekimi. Collider yok, elle yer�ekimi.
     * rayFromMiddle: Z�plama mekani�i i�in, karakterin ortas�ndan a�a��ya at�lan rayin; karakterin ortas�ndan ne kadar a�a��da olaca��.
     * Bu rayi ortadan at�nca karakter z�plam�yor, ona dikkat.
     * rayLength: ��eriden at�lan rayin uzunlu�u.
     */
    public float sprintSpeed = 10f;
    public float walkSpeed = 5f;
    public float sensitivity = 2f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public float rayFromMiddle = 0.9f;
    public float rayLength = 0.13f;
    public AudioClip footstepsClip;

    private CharacterController characterController; 
    private bool isSprinting = false;
    private Vector3 playerVelocity;
    private Vector3 currentLocation;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();  

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        currentLocation = new Vector3(transform.position.x, (transform.position.y - rayFromMiddle), transform.position.z);

        // move mekani�i.

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        CheckSprintInput();

        Vector3 moveDirection = CalculateMoveDirection(horizontalInput, verticalInput);

        MovePlayer(moveDirection);

        //jump mekani�i.  

        if (IsGrounded() && (playerVelocity.y < 0))
        {
            playerVelocity.y = 0f;
        }
          
        if (Input.GetButtonDown("Jump") && IsGrounded())
        { 
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(Vector3.up * playerVelocity.y * Time.deltaTime); 
    }

    private void CheckSprintInput()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift); 
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

    bool IsGrounded()
    {
        // isGrounded de�i�keni �al��mad� :( mecbur metoda kald�k.
        RaycastHit hit;

        Debug.DrawRay(currentLocation, Vector3.down * rayLength, Color.red);

        if (Physics.Raycast(currentLocation, Vector3.down, out hit, rayLength))
        { 
            return true; 
        }  
        return false;
    }

    void PlayFootsteps()
    {
        AudioSource.PlayClipAtPoint(footstepsClip, currentLocation);
    }

}
