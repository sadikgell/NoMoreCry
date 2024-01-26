using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateReactions : MonoBehaviour
{
    [SerializeField] private int remaining = 3;
    [SerializeField] private BoxCollider boxCollider;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("InteractNeg"))
        {
            other.gameObject.tag = "InteractPos";
            // TODO: Öteki nesneye çikolata grafiði eklenecek.
            remaining--;
        }
    } 

    void FixedUpdate()
    {
        if (remaining == 0)
        {
            Destroy(boxCollider.gameObject);
            boxCollider = null;
        }
    }
}
