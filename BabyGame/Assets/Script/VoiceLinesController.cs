using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VoiceLinesController : MonoBehaviour
{ 
    protected AudioSource audioSource;
    public AudioClip[] voiceLines;
    private Boolean gameJustStarted = true;

    // Start is called before the first frame update
    void Start() 
    { 
        audioSource = GetComponent<AudioSource>();
    }
    
    void FixedUpdate()
    {

    }
}
