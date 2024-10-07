using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskChecker : MonoBehaviour
{
    public List<Task> taskList = new List<Task>();
    public AudioManager audioManager;
    [SerializeField] TMP_Text userPrompt;

    private void Start()
    {
        SetupTasks();
    }

    void SetupTasks()
    {
        // Placeholder tasks
        taskList.Add(new Task("Find out what our current working directory is", "pwd", "/root"));
        taskList.Add(new Task("Create a folder called clash in root folder", "mkdir clash", "/root"));
        taskList.Add(new Task("Navigate into the clash folder", "cd clash", "/root/clash"));
        taskList.Add(new Task("Create a file called file.txt in the clash folder", "touch file.txt", "/root/clash"));
        taskList.Add(new Task("Print 'rush'", "echo rush", ""));
        taskList.Add(new Task("Print the names of each file in clash folder", "ls", "/root/clash"));
        taskList.Add(new Task("Delete file.txt", "rm file.txt", "/root/clash"));
        taskList.Add(new Task("Delete clash folder", "rmdir clash", "/root"));
        // Setup User prompt
        SetUserPrompt(taskList[0].taskDescription);
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
            audioManager.PlayCorrect();

            if (taskList.Count > 1)
            {
                taskList.RemoveAt(0);
                SetUserPrompt(taskList[0].taskDescription);
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

    void SetUserPrompt(string prompt)
    {
        userPrompt.SetText("Current Task: " + prompt);
    }
}
