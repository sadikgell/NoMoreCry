using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TaskManager taskManager;
    private BabyActions babyActions;
    public GameObject toys;
    public int toyCount;
    public int inCaseToy = 0;
    // Start is called before the first frame update
    void Start()
    {
        babyActions = GameObject.Find("Bebe").GetComponent<BabyActions>();
        taskManager = GetComponent<TaskManager>();

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
            
        }
        if (inCaseToy == toyCount)
        { 
            taskManager.CompleteTask("Check if the toys are in place.");
        }

    }
}
