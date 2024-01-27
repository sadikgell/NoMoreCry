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
    public List<Material> deriler = new List<Material>();
    private AudioSource babyAudioSource; 
    private Happiness happiness;
    private Interaction interaction;
    private Boolean firstChocolate = true;
    [SerializeField] private float counter = 0f;
    [SerializeField] private Boolean actionAvailable = true;
    private Animator anim; 
    private enum AnimationState { idle, laughing, bored, sleeping }
    private AnimationState state;
    private SkinnedMeshRenderer smr; 

    void Start()
    { 
        happiness = GameObject.Find("GameManager").GetComponent<Happiness>();
        interaction = GameObject.Find("Main Camera").GetComponent<Interaction>(); 
        babyAudioSource = GetComponent<AudioSource>();
        anim = GameObject.Find("BebeArmature").GetComponent<Animator>();
        state = AnimationState.idle;
        smr = GameObject.Find("BebeHead").GetComponent<SkinnedMeshRenderer>();
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
     
    public void BabyHappyReact() 
    {
        smr.SetMaterials(new List<Material>  { deriler[2] }); 
        babyAudioSource.clip = babyVoices[0];
        babyAudioSource.Play(0);
        state = AnimationState.laughing;
        anim.SetInteger("state", (int)state); 
    }

    public void BabySadReact()
    {
        smr.SetMaterials(new List<Material> { deriler[0] });
        babyAudioSource.clip = babyVoices[3];
        babyAudioSource.Play(0);
        state = AnimationState.bored;
        anim.SetInteger("state", (int)state); 
    }

    public void BabyNeutralReact()
    {
        smr.SetMaterials(new List<Material> { deriler[3] });
        babyAudioSource.clip = babyVoices[1];
        babyAudioSource.Play(0);
        state = AnimationState.sleeping;
        anim.SetInteger("state", (int)state); 
    }

    void FoodOrToyCheck(GameObject gameObject)
    {
        if (gameObject.transform.parent.gameObject.name == "Toys")
        {
            Debug.Log("Bu bir oyuncak, fýrlatýyorum.");
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.forward * 5f, ForceMode.Impulse);
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
        Debug.Log("Counter: " + counter);
    }

    void BabyCry()
    {
        smr.SetMaterials(new List<Material> { deriler[1] });  
        babyAudioSource.PlayOneShot(babyVoices[2]); 
        anim.SetTrigger("Cry"); 
        //TODO: Game over ekraný.
    }

    void FixedUpdate()
    {
        if (actionAvailable)
        {
            //babyAudioSource.Stop();
            if (happiness.getHappiness() > 70f)
            {
                
                BabyHappyReact();
            }
            else if (happiness.getHappiness() < 30f)
            {
                BabySadReact();
            }
            else if (happiness.getHappiness() > 30f)
            {
                BabyNeutralReact();
            }
            else if(happiness.getHappiness() < 5f)
            {
                BabyCry();
            }
            actionAvailable = false;
        }

        if (interaction.isInteractBaby == true && babeSwingLimit>0 )
        {
            MakeBabyHappy(2);
            babeSwingLimit--;
            Debug.Log($"{happiness.getHappiness()} :mutluluk  || {babeSwingLimit} : sallama limiti");
        } 

        Counter();
    }
}
