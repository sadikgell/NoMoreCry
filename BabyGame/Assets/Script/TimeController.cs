using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private float remainingTime = 300f; // 5 dakika.
    [SerializeField] private Boolean gameRunningState = false; 
    public float speedUp = 0f; 
    public string remainingTimeText = "5:00"; // Timer'ý oyun içinde kullanýrken direkt bu deðiþkeni kullanýn.
    private TextMeshProUGUI timerText;
     
    void Start()
    {
        gameRunningState = true;
        try
        {
            timerText = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    } 
    
    void FixedUpdate()
    {
        // Part 1.
        if (gameRunningState)
        {
            if (!(remainingTime <= 0f))
            {
                //Debug.Log($"Remaining Time: {remainingTime}, Remaining Time Text: {remainingTimeText}");
                updateTime(speedUp);
            }
            else
            {
                gameRunningState = false;
            }
        } 

        // Part 2.
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = remainingTimeText;
        }
    }

    public bool IsTimeZero()
    {
        return remainingTime <= 0f;
    }

    private void GetRemainingTime()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60F);
        int seconds = Mathf.FloorToInt(remainingTime - minutes * 60);
        remainingTimeText = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    private void updateTime(float speedup) 
    {         
        remainingTime = remainingTime - Time.deltaTime - speedup;
        GetRemainingTime();
    }

    public Boolean getGameRunningState()
    {
        return gameRunningState;
    }
}
