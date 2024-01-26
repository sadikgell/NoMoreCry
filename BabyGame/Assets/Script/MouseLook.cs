using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseLook : MonoBehaviour
{
    public float sensitivity = 2f;
    public float verticalLookRange = 90f;

    private float rotationX = 0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        transform.Rotate(Vector3.up * mouseX);

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -verticalLookRange, verticalLookRange);

        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
