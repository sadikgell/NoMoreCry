using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public Image crosshair;
    public float distance;
    public bool isInteract = false;
    public GameObject interactableObject;
    private Vector3 initialObjectPosition;
    public float maxDistanceFromPlayer = 1.5f;
    public float dropDistanceThreshold = 1.5f;
    public float maxDropDistance = 5f; 

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        


        if (Physics.Raycast(transform.position, forward, out hit))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);

            if (hit.distance <= distance && (hit.collider.gameObject.tag == "InteractNeg" || hit.collider.gameObject.tag == "InteractPos"))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (!isInteract)
                    {
                        interactableObject = hit.collider.gameObject;
                        initialObjectPosition = interactableObject.transform.position;
                        isInteract = true; 
                        hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false; 
                    }
                    Debug.Log($"isInteract :{isInteract}");
                    Debug.Log($"interactableObject :{interactableObject}");
                } 
            }
        }

        if (isInteract && interactableObject != null)
        {
            Vector3 targetPosition = transform.position + forward * maxDistanceFromPlayer;
            interactableObject.transform.position = Vector3.Lerp(
                interactableObject.transform.position, targetPosition, Time.deltaTime * 10f);
        }

        // Check if the object is within the drop distance threshold
        if (!Input.GetKey(KeyCode.F) && isInteract && interactableObject != null)
        {
            float distanceToInitialPosition = Vector3.Distance(interactableObject.transform.position, initialObjectPosition);
            float playerToInitialPositionDistance = Vector3.Distance(transform.position, initialObjectPosition);

            interactableObject.GetComponent<Collider>().gameObject.GetComponent<Rigidbody>().useGravity = true;

            if (distanceToInitialPosition <= dropDistanceThreshold && playerToInitialPositionDistance <= maxDropDistance)
            {
                interactableObject.transform.position = initialObjectPosition;
                isInteract = false;
            }
        }
    } 
}
