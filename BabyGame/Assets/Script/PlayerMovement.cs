using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /* Deðiþken açýklamalarý:
     * sprintSpeed: Koþarkenki hýzýmýz.
     * walkSpeed: Yürürkenki hýzýmýz.
     * sensitivity: Fare hassasiyeti.
     * jumpHeight: Zýplama yüksekliði. Arttýrdýkça zýplama oraný artýyor.
     * gravityValue: Yerçekimi. Collider yok, elle yerçekimi.
     * rayFromMiddle: Zýplama mekaniði için, karakterin ortasýndan aþaðýya atýlan rayin; karakterin ortasýndan ne kadar aþaðýda olacaðý.
     * Bu rayi ortadan atýnca karakter zýplamýyor, ona dikkat.
     */
    public float sprintSpeed = 10f;
    public float walkSpeed = 5f;
    public float sensitivity = 2f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public float rayFromMiddle = 1f;

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

        // move mekaniði.

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        CheckSprintInput();

        Vector3 moveDirection = CalculateMoveDirection(horizontalInput, verticalInput);

        MovePlayer(moveDirection);

        //jump mekaniði. 

        Debug.Log($"Character Ground Mu: {IsGrounded()}");

        if (IsGrounded() && (playerVelocity.y < 0))
        {
            playerVelocity.y = 0f;
        }
          
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Debug.Log($"Zýplýyoruz.");
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
         
        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime); 
    }

    private void CheckSprintInput()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift);

        /* 
         * Bu da, yukarýdaki de boolean döndürüyor, buna hiç gerek yok.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
        */
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
        // isGrounded deðiþkeni çalýþmadý :( mecbur metoda kaldýk.
        float rayLength = 1f; // Ýçeriden atýlan rayin uzunluðu.
        RaycastHit hit;

        Debug.DrawRay(currentLocation, Vector3.down * rayLength, Color.red);

        if (Physics.Raycast(currentLocation, Vector3.down, out hit, rayLength))
        { 
            return true; 
        }  
        return false;
    }

}
