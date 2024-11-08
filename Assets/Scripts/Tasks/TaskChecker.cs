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
    [SerializeField] TMP_Text scoreDisplay;
    [SerializeField] TMP_Text timer;
    [SerializeField] TMP_Text failedText;
    public int currentScore = 0;
    private float timeTracked = 0;
    private float timeLeft = 0;

    private void Start()
    {
        fileSystem = GameObject.FindObjectOfType<FileSystem>();
        SetupTasks();
    }

    private void Update()
    {
        timeTracked += Time.deltaTime;
        timeLeft = Mathf.RoundToInt((taskList[0].pointValue*15) - timeTracked);
        timer.text = "TIME LEFT: " + timeLeft;
        if (timeLeft <= 0)
        {
            OnTaskCompleted(false);
        }
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
            OnTaskCompleted(true);
        }
    }

    void OnTaskCompleted(bool success)
    {
        if (taskList.Count > 0)
        {
            if (success)
            {
                Debug.Log("TASK COMPLETED!");
                audioManager.PlayCorrect();
                CalculateScore();
            }
            else 
            {
                Debug.Log("TASK FAILED");
                StartCoroutine(FailedTextEnabled());
            }
            

            if (taskList.Count > 1)
            {
                taskList.RemoveAt(0);
                SetupNextTask();
                timeTracked = 0;
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

    void CalculateScore()
    {
        currentScore += Mathf.RoundToInt(taskList[0].pointValue / (timeTracked * 0.1f));
        scoreDisplay.text = "Score: " + currentScore.ToString();
        timeTracked = 0;
    }

    private IEnumerator FailedTextEnabled()
    {
        failedText.enabled = true; 
        yield return new WaitForSeconds(2); 
        failedText.enabled = false; 
    }
}
