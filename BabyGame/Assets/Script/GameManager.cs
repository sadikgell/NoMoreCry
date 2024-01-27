using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TaskManager taskManager;
    private BabyActions babyActions;
    public GameObject toys;
    public TextMeshPro task1;
    public TextMeshPro task2;
    public int toyCount;
    public int inCaseToy = 0;
    // Start is called before the first frame update
    void Start()
    {
        babyActions = GameObject.Find("Bebe").GetComponent<BabyActions>();
        taskManager = GetComponent<TaskManager>();


        task1 = GameObject.Find("Task1").GetComponent<TextMeshPro>();
        task2 = GameObject.Find("Task2").GetComponent<TextMeshPro>();

        toys = GameObject.Find("Toys");
        toyCount = 1;
        Debug.Log(toyCount);

    }

    // Update is called once per frame
    void Update()
    {
        

        if (babyActions.foodCounter == 2)
        {
            taskManager.CompleteTask("Feed the baby two meals.");
            babyActions.foodCounter = -1;
            task1.text = $"<s>{task1.text}</s>";



        }
        if (inCaseToy == toyCount)
        {
            taskManager.CompleteTask("Check if the toys are in place.");
            task2.text = $"<s>{task2.text}</s>";
        }

    }
}
