using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BabyActions : MonoBehaviour
{

    private BoxCollider babyCollider;
    private Happiness happiness;
    private Interaction interaction;
    // Start is called before the first frame update
    void Start()
    {
        babyCollider = GetComponent<BoxCollider>();
        happiness = GameObject.Find("GameManager").GetComponent<Happiness>();
        interaction = GameObject.Find("Main Camera").GetComponent<Interaction>();
        //Debug.Log($"{babyCollider.gameObject.name},{happiness.gameObject.name}");
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"Trigger entered. Colliding object tag: {other.gameObject.tag}");

        if (other.gameObject.CompareTag("InteractPos"))
        {
            //Debug.Log("Bebeði mutlu ettiniz.");
            MakeBabyHappy();
            FoodOrToyCheck(other.gameObject);
            InteractionClear();
        }
        else if (other.gameObject.CompareTag("InteractNeg"))
        {
            //Debug.Log("Bebeði mutsuz ettiniz.");
            MakeBabySad();
            FoodOrToyCheck(other.gameObject);
            InteractionClear();
        }
    } 

    private void MakeBabyHappy()
    {
        happiness.increaseHappiness(5);
    }

    private void MakeBabySad()
    { 
        happiness.decreaseHappiness(5);
    }

    void BabyHappyReact() 
    {
        //Debug.Log("Happy react.");
    }

    void BabySadReact()
    {
        //Debug.Log("Sad react.");
    }

    void BabyNeutralReact()
    {
        //Debug.Log("Neutral react.");
    }


    //Interaction scriptinde düzenleme
    void InteractionClear()
    { 
        interaction.isInteract = false;
        interaction.interactableObject = null;
    }


    void FixedUpdate()
    {
        if (happiness.getHappiness() > 70f)
        {
            BabyHappyReact();
        }
        else if(happiness.getHappiness() < 30f)
        {
            BabySadReact();
        }
        else
        {
            BabyNeutralReact();
        }
    }

    void FoodOrToyCheck(GameObject gameObject)
    {
        if (gameObject.transform.parent.gameObject.name == "Toys")
        {
            Debug.Log("Bu bir oyuncak, fýrlatýyorum.");
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.back * 5f, ForceMode.Impulse);
            rb.useGravity = true;
        }
        else if(gameObject.transform.parent.gameObject.name == "Food")
        {
            Debug.Log("Bu bir yiyecek, yiyorum.");
            Destroy(gameObject);
        }
        else
        {
            //Do nothing.
        }
    }
}
