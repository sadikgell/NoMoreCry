using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TaskManager taskManager;
    private BabyActions babyActions;

    // Start is called before the first frame update
    void Start()
    {
        babyActions = GameObject.Find("Bebe").GetComponent<BabyActions>();
        taskManager = GetComponent<TaskManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (babyActions.foodCounter == 2)
        {
            taskManager.CompleteTask(taskManager.tasks[0]);
            babyActions.foodCounter = -1;
        }        
    }
}
