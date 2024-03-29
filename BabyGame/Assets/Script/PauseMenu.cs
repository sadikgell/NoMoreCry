using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour

{
    public bool isActive = false;
    public bool isActiveVoice = true;
    public GameObject PauseM;

    private AudioSource playerAudio;
    private AudioSource TVAudio;
    private AudioSource BabyAudio;


    // Start is called before the first frame update
    void Start()
    {

        PauseM = GameObject.Find("PauseM");

        playerAudio = GameObject.Find("Player").GetComponent<AudioSource>();
        TVAudio = GameObject.Find("GameJamTV").GetComponent<AudioSource>();
        BabyAudio = GameObject.Find("Bebe").GetComponent<AudioSource>();
        Resume();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P");
            if (isActive)
            {
                Resume();
                
            }
            else
            {
                Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (isActiveVoice)
            {
                AudioListener.volume = 0;
                isActiveVoice= false;
            }
            else
            {
                AudioListener.volume = 1;
                isActiveVoice= true;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(0);
            
        }
    }
    public void Resume()
    {
        PauseM.SetActive(false);
        Time.timeScale = 1.0f;
        isActive = false;
        Debug.Log("Resume");
        TVAudio.UnPause();
        playerAudio.UnPause();
        BabyAudio.UnPause();
    }
    public void Pause()
    {
        PauseM.SetActive(true);
        Time.timeScale = 0;
        isActive = true;
        Debug.Log("Pause");
        TVAudio.Pause();
        playerAudio.Pause();
        BabyAudio.Pause();
    }
}
