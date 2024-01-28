using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VoiceOnOff : MonoBehaviour
{

    public TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update

    void Start()
    {
        textMeshPro = GameObject.Find("SoundsOnOF").GetComponent<TextMeshProUGUI>();
    }

    public void OnButtonPress()
    {

        if (textMeshPro.text == "Sound ON")
        {
            // Change the text property
            textMeshPro.SetText("Sound OFF");
            AudioListener.volume = 0;
        }
        else
        {
            textMeshPro.SetText("Sound ON");
            AudioListener.volume = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
