using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEditor : MonoBehaviour
{

    private void Update()
    {
      
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
        SceneManager.LoadScene(3);
    }
    public void LoseScreen()
    {
        //2 temsili index sayýsý en son tekrar deðiþtilir
        SceneManager.LoadScene(2);
    }


}
