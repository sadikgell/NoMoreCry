using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Task
{
    public string description;
    public bool isCompleted;
    public int rewardPoints;


    public Task(string desc, int reward)
    {
        description = desc;
        isCompleted = false;
        rewardPoints = reward;
    }
}

public class TaskManager : MonoBehaviour
{
    public List<Task> tasks = new List<Task>();
    public Text taskDisplayText;

    void Start()
    {
        tasks.Add(new Task("Feed the baby two meals", 50));
        tasks.Add(new Task("Check if the toys are in place", 50));
        foreach (var task in tasks)
        {
            Debug.Log(task);
        }
        UpdateTaskDisplay();
    }

    public void AddTask(Task newTask)
    {
        tasks.Add(newTask);
        UpdateTaskDisplay();
    }

    public void CompleteTask(Task task)
    {
        task.isCompleted = true;
        tasks.Remove(task);
        UpdateTaskDisplay();

        if (AreAllTasksComplete())
        {
            Debug.Log("tasklar bitti");
        }
    }
    void UpdateTaskDisplay()
    {
        if (taskDisplayText != null)
        {
            string taskText = "Tasks:\n";
            foreach (Task task in tasks)
            {
                taskText += $"{(task.isCompleted ? "[X]" : "[ ]")} {task.description} ({task.rewardPoints} points)\n";
            }
            taskDisplayText.text = taskText;
        }
    }

    bool AreAllTasksComplete()
    {
        foreach (Task task in tasks)
        {
            if (!task.isCompleted)
            {
                return false;
            }
        }
        return true;
    }


}
