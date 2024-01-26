using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngineInternal;

public class Interaction : MonoBehaviour
{
    public Image crosshair;
    public float distance;
    public bool isInteract = false;
    private GameObject interactableObject;
    private Vector3 initialObjectPosition;
    public float maxDistanceFromPlayer = 0.5f;
    public float dropDistanceThreshold = 1.5f;


    private void Start()
    {
        
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, forward, out hit))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);

            if (hit.distance <= distance && hit.collider.gameObject.tag == "InteractNeg" || hit.collider.gameObject.tag == "InteractPos")
            {
                interactableObject = hit.collider.gameObject;

                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (!isInteract)
                    {
                        // Store the initial position when picking up the object
                        initialObjectPosition = interactableObject.transform.position;
                    }

                    isInteract = !isInteract;
                }
            }
        }
        if (isInteract && interactableObject != null)
        {
            Vector3 targetPosition = transform.position + forward * maxDistanceFromPlayer;
            interactableObject.transform.position = Vector3.Lerp(
                interactableObject.transform.position, targetPosition, Time.deltaTime * 10f);
        }
        if (!isInteract && interactableObject != null)
        {
            float distanceToInitialPosition = Vector3.Distance(interactableObject.transform.position, initialObjectPosition);
            if (distanceToInitialPosition <= dropDistanceThreshold)
            {
                interactableObject.transform.position = initialObjectPosition;
            }

        }
    }
}
