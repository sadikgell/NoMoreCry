using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BabyActions : MonoBehaviour
{

    private BoxCollider babyCollider;
    private Happiness happiness;
    private Interaction interaction;
    public int foodCounter = 0;
    private Boolean firstChocolate = true;
 
    void Start()
    {
        babyCollider = GetComponent<BoxCollider>();
        happiness = GameObject.Find("GameManager").GetComponent<Happiness>();
        interaction = GameObject.Find("Main Camera").GetComponent<Interaction>(); 
    }

    public void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.CompareTag("InteractPos"))
        {
            //Debug.Log("Bebeði mutlu ettiniz.");
            MakeBabyHappy();
            FoodOrToyCheck(other.gameObject);
            interaction.InteractionClear();
        }
        else if (other.gameObject.CompareTag("InteractNeg"))
        {
            //Debug.Log("Bebeði mutsuz ettiniz.");
            MakeBabySad();
            FoodOrToyCheck(other.gameObject);
            interaction.InteractionClear();
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

    // TODO: React animations.
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
            rb.isKinematic = false;
        }
        else if(gameObject.transform.parent.gameObject.name == "Food")
        {
            Debug.Log("Bu bir yiyecek, yiyorum.");
            foodCounter++;
            if (gameObject.name == "GameJamChocolate" && firstChocolate)
            {
                GameObject.Find("Player").GetComponent<VoiceLinesController>().fedChocolate = true;
                firstChocolate = false;
                Debug.Log("Kutsal çikolata verildi.");
            }
            Destroy(gameObject);
        }
        else
        {
            //Do nothing.
        }
    }
}
