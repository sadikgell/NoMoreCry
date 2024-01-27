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
    [SerializeField] private float counter = 15f;

    // Start is called before the first frame update
    void Start() 
    {
        try
        {
            audioSource = GetComponent<AudioSource>();
            happiness = GameObject.Find("GameManager").GetComponent<Happiness>(); 
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
            audioSource.PlayOneShot(voiceLines[0]); // here we go again.
            gameJustStarted = false;
            Debug.Log("Oyun baþladý.");
        }
        else if(fedChocolate)
        {
            audioSource.PlayOneShot(voiceLines[5]); // chocolate
            fedChocolate = false;
            Debug.Log("Çikolata verildi.");
        }
        else if (happiness.getHappiness() >= 75f && actionAvailable)
        {
            audioSource.PlayOneShot(voiceLines[1]); // aint half bad
            actionAvailable = false;
            Debug.Log("Mutlu.");
        }
        else if (happiness.getHappiness() <= 30f && actionAvailable)
        {
            System.Random random = new System.Random();
            int randomIndex = random.Next(1, 3);
            if (randomIndex == 1)
            {
                audioSource.PlayOneShot(voiceLines[6]); // shut up
            }
            else
            {
                audioSource.PlayOneShot(voiceLines[4]); // luck you
            }
            actionAvailable = false;
            Debug.Log("Mutsuz.");
        } 
        //TODO: Else if oyun biterse, bitiþ sesini oynat , 2 ve 3.
        //TODO: Else if kazanýrsak, kazanma sesi, 7. 
    }

    private void Counter()
    {
        if (counter <= 0f)
        { 
            counter = 10f;
            actionAvailable = true;
        }
        counter -= Time.deltaTime;
    }


    /*
     * BabyAction'da deðiþtirdiðim yer. -Semih
     if (gameObject.name == "GameJamChocolate" && firstChocolate)
            {
                GameObject.Find("Player").GetComponent<VoiceLinesController>().fedChocolate = true;
                firstChocolate = false;
                Debug.Log("Kutsal çikolata verildi.");
            }
     */
}
