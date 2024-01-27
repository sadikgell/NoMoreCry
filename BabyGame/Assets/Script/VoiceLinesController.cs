using System;
using UnityEngine;

public class VoiceLinesController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] voiceLines;
    private Boolean gameJustStarted = true;
    private Happiness happiness;    
    [SerializeField] private float counter = 0f;

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
        if (counter <= 0f)
        {
            PlayPlayerVoices();
            counter = 15f;
        }
        counter -= Time.deltaTime; 
    }

    private void PlayPlayerVoices()
    {
        try
        {
            if (gameJustStarted)
            {
                audioSource.PlayOneShot(voiceLines[0]); // here we go again.
                gameJustStarted = false;
            }
            else if (happiness.getHappiness() >= 75f)
            {
                audioSource.PlayOneShot(voiceLines[1]); // aint half bad
            }
            else if (happiness.getHappiness() <= 30f)
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
            }
            //TODO: Else if oyun biterse, bitiþ sesini oynat , 2 ve 3.
            //TODO: Else if kazanýrsak, kazanma sesi, 7.
            //TODO: Çikolata sesi, 5. 
        }
        catch (Exception e)
        {
            Debug.LogError("VoiceLinesController()'da kritik hata: " + e.Message);
        } 
    }
}
