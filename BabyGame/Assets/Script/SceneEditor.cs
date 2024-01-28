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
        task = GameObject.Find("GameManager").GetComponent<TaskManager>();
    }


    private void Update()
    {
       

        if (happiness.getHappiness() <= 0)
        {
            LoseScreen();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (time.IsTimeZero())
        {

            if (task.AllTaskComplete())
            {
                WinScreen();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                LoseScreen();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
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
    public void StartLevel1()
    {
        SceneManager.LoadScene(2);
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
    public void CreditsScreen()
    {
        //2 temsili index sayýsý en son tekrar deðiþtilir
        SceneManager.LoadScene(5);
    }
    public void SettingsScreen()
    {
        SceneManager.LoadScene(6);
    }

    public void TutorialScreen()
    {
        SceneManager.LoadScene(7);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}