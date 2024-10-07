using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskChecker : MonoBehaviour
{
    public List<Task> taskList = new List<Task>();

    TaskChecker()
    {
        // Placeholder tasks
        taskList.Add(new Task("Find out what our current working directory is", "pwd", "/root"));
        taskList.Add(new Task("Create a folder called miners in root folder", "mkdir miners", "/root"));
        taskList.Add(new Task("Navigate into the miners folder", "cd miners", "/root/miners"));
        taskList.Add(new Task("Create a file called file.txt in the miners folder", "touch file.txt", "/root/miners"));
        taskList.Add(new Task("Print 'rush'", "echo rush", ""));
        taskList.Add(new Task("Print the names of each file in miners folder", "ls", "/root/miners"));
        taskList.Add(new Task("Delete file.txt", "rm file.txt", "/root/miners"));
        taskList.Add(new Task("Delete miners folder", "rmdir miners", "/root"));
    }

    // Check if the current task has been completed succesfully,
    // called after a command is entered.
    public void CheckTask(string command, string directory)
    {
        if (command == taskList[0].commandToRun && (directory == taskList[0].workingDirectory || taskList[0].workingDirectory == ""))
        {
            OnTaskCompleted();
        }
    }

    void OnTaskCompleted()
    {
        if (taskList.Count > 0)
        {
            Debug.Log("TASK COMPLETED!");

            if (taskList.Count > 1)
            {
                taskList.RemoveAt(0);
            }
            else
            {
                taskList.RemoveAt(0);
                AllTasksCompleted();
                Debug.Log("ALL TASKS COMPLETE!");
            }
        }
    }

    void AllTasksCompleted()
    {
        SceneManager.LoadScene("VictoryScene", LoadSceneMode.Single);
    }
}
