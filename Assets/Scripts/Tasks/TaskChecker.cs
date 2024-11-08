using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskChecker : MonoBehaviour
{
    private TaskGenerator taskGenerator = new TaskGenerator();
    private FileSystem fileSystem;
    public List<Task> taskList;
    public AudioManager audioManager;
    [SerializeField] TMP_Text userPrompt;

    private void Start()
    {
        fileSystem = GameObject.FindObjectOfType<FileSystem>();
        SetupTasks();
    }

    void SetupTasks()
    {
        taskList = taskGenerator.GenerateTaskList(10);

        if (taskList.Count > 0)
        {
            SetupNextTask();
        } else
        {
            Debug.Log("Task List is empty");
        }
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
                SetupNextTask();
            }
            else
            {
                taskList.RemoveAt(0);
                AllTasksCompleted();
                Debug.Log("ALL TASKS COMPLETE!");
            }
        }
    }

    void SetupNextTask()
    {
        fileSystem.ResetFileSystem(taskList[0].requiredFolders, taskList[0].requiredFiles);
        SetUserPrompt(taskList[0].taskDescription);
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
