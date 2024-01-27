using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairManager : MonoBehaviour
{
    public Image crosshair;
    public GameObject interactOutline;
    public float interactableDistance = 5f;

    void Update()
    {
        HandleCrosshair();
    }

    void HandleCrosshair()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, forward, out hit, interactableDistance))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);

            bool isInteractableObject = hit.collider.gameObject.CompareTag("InteractNeg") ||
                                        hit.collider.gameObject.CompareTag("InteractPos") ||
                                        hit.collider.gameObject.CompareTag("Baby");

            if (isInteractableObject)
            {
                ActivateInteractOutline();
            }
            else
            {
                DeactivateInteractOutline();
            }
        }
        else
        {
            DeactivateInteractOutline();
        }
    }

    void ActivateInteractOutline()
    {
        if (interactOutline != null)
        {
            interactOutline.SetActive(true);
        }
    }

    void DeactivateInteractOutline()
    {
        if (interactOutline != null)
        {
            interactOutline.SetActive(false);
        }
    }
}
