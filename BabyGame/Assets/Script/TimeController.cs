using System;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private float remainingTime = 300f; // 5 dakika.
    [SerializeField] private Boolean gameRunningState = false; 
    public float speedUp = 0f; 
    public string remainingTimeText = "5:00"; // Timer'ý oyun içinde kullanýrken direkt bu deðiþkeni kullanýn.
     
    void Start()
    {
        gameRunningState = true; 
    } 
    
    void Update()
    {
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
