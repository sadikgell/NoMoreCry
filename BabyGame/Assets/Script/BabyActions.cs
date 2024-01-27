using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class BabyActions : MonoBehaviour
{
    public int babeSwingLimit = 5;
    public int foodCounter = 0;
    public List<AudioClip> babyVoices = new List<AudioClip>();
    private AudioSource babyAudioSource;
    private BoxCollider babyCollider;
    private Happiness happiness;
    private Interaction interaction;
    private Boolean firstChocolate = true;
    [SerializeField] private float counter = 0f;
    [SerializeField] private Boolean actionAvailable = true;
 
    void Start()
    {
        babyCollider = GetComponent<BoxCollider>();
        happiness = GameObject.Find("GameManager").GetComponent<Happiness>();
        interaction = GameObject.Find("Main Camera").GetComponent<Interaction>(); 
        babyAudioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.CompareTag("InteractPos"))
        {
            //Debug.Log("Bebeði mutlu ettiniz.");
            MakeBabyHappy(5);
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

    private void MakeBabyHappy(int boost)
    {
        happiness.increaseHappiness(boost);
    }

    private void MakeBabySad()
    { 
        happiness.decreaseHappiness(5);
    }

    // TODO: React animations.
    public void BabyHappyReact() 
    {
        babyAudioSource.PlayOneShot(babyVoices[0]);
    }

    public void BabySadReact()
    {
        babyAudioSource.PlayOneShot(babyVoices[1]);
    }

    public void BabyNeutralReact()
    {
        babyAudioSource.PlayOneShot(babyVoices[2]);
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
     
    private void Counter()
    {
        if (counter <= 0f)
        {
            counter = 12f;
            actionAvailable = true;
        }
        counter -= Time.deltaTime;
    }


    void FixedUpdate()
    {
        if (actionAvailable)
        {
            if (happiness.getHappiness() > 70f)
            {
                BabyHappyReact();
            }
            else if (happiness.getHappiness() < 30f)
            {
                BabySadReact();
            }
            else
            {
                BabyNeutralReact();
            }
            actionAvailable = false;
        }

        if (interaction.isInteractBaby == true && babeSwingLimit>0 )
        {
            MakeBabyHappy(2);
            babeSwingLimit--;
            Debug.Log($"{happiness.getHappiness()} :mutluluk  || {babeSwingLimit} : sallama limiti");
        }
    }
}
