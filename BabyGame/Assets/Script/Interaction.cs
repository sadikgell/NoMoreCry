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
    public float maxDistanceFromPlayer = 0.5f;
    // Update is called once per frame
    private void Start()
    {
        
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if(Physics.Raycast(transform.position, forward, out hit))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            
            if(hit.distance <= distance && hit.collider.gameObject.tag == "Interact")
            {
                interactableObject = hit.collider.gameObject;

                if (Input.GetKeyDown(KeyCode.F))
                {
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

    }
}
