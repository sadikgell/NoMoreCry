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

    public bool isInteractBaby;

    private AudioSource tvAudio;
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;




        if (Physics.Raycast(transform.position, forward, out hit))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);

            Debug.Log(hit.collider.gameObject.name.ToString());


            if (hit.distance <= distance &&
                (hit.collider.gameObject.tag == "InteractNeg" ||
                hit.collider.gameObject.tag == "InteractPos" ||
                hit.collider.gameObject.tag == "Baby"))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (!isInteract)
                    {
                        interactableObject = hit.collider.gameObject;
                        initialObjectPosition = interactableObject.transform.position;
                        isInteract = true;
                        //hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false; 
                        hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                        if (hit.collider.gameObject.tag == "Baby")
                        {
                            isInteractBaby = true;
                        }

                    }
                    //Debug.Log($"isInteract :{isInteract}");
                    //Debug.Log($"interactableObject :{interactableObject}");
                }
            }
            if (hit.collider.gameObject.tag == "TV")
            {
               
                // Null referans kontrolü ekleyin
                if (hit.collider.gameObject.transform.GetChild(1) != null)
                {
                   
                    tvAudio = hit.collider.gameObject.transform.GetChild(1).GetComponent<AudioSource>();

                    // Float deðerleri karþýlaþtýrmak için Mathf.Approximately kullanýn
                    if (Input.GetMouseButtonDown(0) && Mathf.Approximately(tvAudio.volume, 0.1f))
                    {
                        tvAudio.volume = 0f;
                    }
                    else if (Input.GetMouseButtonDown(0) && Mathf.Approximately(tvAudio.volume, 0))
                    {
                        tvAudio.volume = 0.1f;
                    }
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



            if (distanceToInitialPosition <= dropDistanceThreshold && playerToInitialPositionDistance <= maxDropDistance)
            {
                interactableObject.GetComponent<Collider>().gameObject.GetComponent<Rigidbody>().isKinematic = false;
                interactableObject.transform.position = initialObjectPosition;
                isInteract = false;

                if (isInteractBaby) isInteractBaby = false;
            }
        }
    }
    public void InteractionClear()
    {
        isInteract = false;
        interactableObject = null;
    }
}
