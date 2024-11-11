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
    private TerminalUI terminalUI;
    public List<Task> taskList;
    public AudioManager audioManager;
    [SerializeField] TMP_Text userPrompt;
    [SerializeField] TMP_Text scoreDisplay;
    [SerializeField] TMP_Text timer;
    [SerializeField] TMP_Text failedText;
    [SerializeField] TMP_Text newScoreText;
    public int currentScore = 0;
    private float timeTracked = 0;
    private float timeLeft = 0;

    private void Start()
    {
        fileSystem = GameObject.FindObjectOfType<FileSystem>();
        terminalUI = GameObject.FindObjectOfType<TerminalUI>();
        SetupTasks();
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (taskList.Count >= 1)
        {
            timeTracked += Time.deltaTime;
            timeLeft = Mathf.RoundToInt((taskList[0].pointValue*15) - timeTracked);
            timer.text = "TIME LEFT: " + timeLeft;
            if (timeLeft <= 0)
            {
                OnTaskCompleted(false);
                audioManager.PlayError();
            }
        }
 
    }

    void SetupTasks()
    {
        taskList = taskGenerator.GenerateTaskList();

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

            terminalUI.ClearScreen();

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
        terminalUI.UpdateDifficulty(taskList[0].pointValue);
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
        int newScore = Mathf.RoundToInt(taskList[0].pointValue * (1000 / (timeTracked + 1)));
        currentScore += newScore;
        scoreDisplay.text = "Score: " + currentScore.ToString();
        timeTracked = 0;
        StartCoroutine(NewScoreEnabled(newScore));
    }

    private IEnumerator NewScoreEnabled(int newScore)
    {
        newScoreText.enabled = true;
        newScoreText.text = $"+{newScore} score";
        yield return new WaitForSeconds(2);
        if (newScoreText)
        {
            newScoreText.enabled = false;
        }
    }

    private IEnumerator FailedTextEnabled()
    {
        failedText.enabled = true;
        yield return new WaitForSeconds(2);
        failedText.enabled = false;
    }
}
