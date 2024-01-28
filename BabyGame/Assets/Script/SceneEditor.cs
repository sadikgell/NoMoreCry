using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEditor : MonoBehaviour
{
    public Happiness happiness;
    public TimeController time;
    public TaskManager task;


    private void Start()
    {
        happiness = GameObject.Find("GameManager").GetComponent<Happiness>();
        time = GameObject.Find("GameManager").GetComponent<TimeController>();
    }


    private void Update()
    {
      if(happiness.getHappiness() <= 0)
        {
            LoseScreen();
        }
        if (time.IsTimeZero())
        {
            if (task.AllTaskComplete())
            {
                WinScreen();
            }
            else
            {
                LoseScreen();
            }
        }
    }
    
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void WinScreen()
    {
        //3 temsili index sayýsý en son tekrar deðiþtilir
        SceneManager.LoadScene(4);
    }
    public void LoseScreen()
    {
        //2 temsili index sayýsý en son tekrar deðiþtilir
        SceneManager.LoadScene(3);
    }


}
