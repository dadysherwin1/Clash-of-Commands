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
    [SerializeField] TMP_Text scoreDisplay;
    [SerializeField] TMP_Text timer;
    [SerializeField] TMP_Text failedText;
    public int currentScore = 0;
    private float timeTracked = 0;
    private float timeLeft = 0;

    private void Start()
    {
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
        // Placeholder tasks
        taskList.Add(new Task("Find out what our current working directory is", "pwd", "/root" ,1));
        taskList.Add(new Task("Create a folder called clash in root folder", "mkdir clash", "/root", 1));
        taskList.Add(new Task("Navigate into the clash folder", "cd clash", "/root/clash", 1));
        taskList.Add(new Task("Create a file called file.txt in the clash folder", "touch file.txt", "/root/clash", 1));
        taskList.Add(new Task("Print 'rush'", "echo rush", "", 1));
        taskList.Add(new Task("Print the names of each file in clash folder", "ls", "/root/clash", 1));
        taskList.Add(new Task("Delete file.txt", "rm file.txt", "/root/clash", 2));
        taskList.Add(new Task("Delete clash folder", "rmdir clash", "/root", 2));
        // Setup User prompt
        SetUserPrompt(taskList[0].taskDescription);
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
                SetUserPrompt(taskList[0].taskDescription);
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
