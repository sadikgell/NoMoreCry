using System;
using UnityEngine;

public class VoiceLinesController : MonoBehaviour
{
    private AudioSource audioSource;
    private Happiness happiness;
    public AudioClip[] voiceLines;
    public Boolean fedChocolate = false;
    public Boolean actionAvailable = false;
    [SerializeField] private Boolean gameJustStarted = true;
    [SerializeField] private float counter = 10f;
    private TimeController timeController;
     
    void Start() 
    {
        try
        {
            audioSource = GetComponent<AudioSource>();
            happiness = GameObject.Find("GameManager").GetComponent<Happiness>();
            timeController = GameObject.Find("GameManager").GetComponent<TimeController>();
        }
        catch (Exception e)
        {
            Debug.LogError("VoiceLinesController()'da kritik hata: "+e.Message);
        }
    }
    
    void FixedUpdate()
    {
        Counter(); 

        if (gameJustStarted)
        { 
            audioSource.clip = voiceLines[0];
            audioSource.Play(0);
            gameJustStarted = false;
            //Debug.Log("Oyun baþladý.");
        }
        else if(fedChocolate)
        {
            audioSource.clip = voiceLines[5];
            audioSource.Play(0);// chocolate
            fedChocolate = false;
            //Debug.Log("Çikolata verildi.");
        }else if (actionAvailable && timeController.getRemainingTime() <= 10f && happiness.getHappiness() >= 20f) //oyunu kazandý.
        {
            audioSource.clip = voiceLines[7];
            audioSource.Play(0);
            actionAvailable = false;
        }
        else if (happiness.getHappiness() >= 85f && actionAvailable)
        {
            audioSource.clip = voiceLines[1];
            audioSource.Play(0); // aint half bad
            actionAvailable = false;
            //ebug.Log("Mutlu.");
        }
        else if (happiness.getHappiness() <= 15f && happiness.getHappiness() >= 5f && actionAvailable)
        {
            System.Random random = new System.Random();
            int randomIndex = random.Next(1, 3);
            if (randomIndex == 1)
            {
                audioSource.clip = voiceLines[6];
                audioSource.Play(0); // shut up
            }
            else
            {
                audioSource.clip = voiceLines[4];
                audioSource.Play(0); // luck you
            }
            actionAvailable = false;
            //Debug.Log("Mutsuz.");
        }
        else //oyun kaybedilirse
        {
            System.Random random = new System.Random();
            int randomIndex = random.Next(1, 3);
            if (randomIndex == 1)
            {
                audioSource.clip = voiceLines[2];
                audioSource.Play(0);
            }
            else
            {
                audioSource.clip = voiceLines[3];
                audioSource.Play(0);
            }
            actionAvailable = false;
        } 
    }

    private void Counter()
    {
        if (counter <= 0f)
        { 
            counter = 25f;
            actionAvailable = true;
        }
        counter -= Time.deltaTime;
    } 
}
