using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateReactions : MonoBehaviour
{
    [SerializeField] private int remaining = 3;
    [SerializeField] private GameObject box;
    void Start()
    {
        box = GetComponent<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("InteractNeg"))
        {
            other.gameObject.tag = "InteractPos";
            // TODO: �teki nesneye �ikolata grafi�i eklenecek.
            remaining--;
        }
    } 

    void FixedUpdate()
    {
        if (remaining == 0)
        {
            Destroy(box);
            
        }
    }
}
