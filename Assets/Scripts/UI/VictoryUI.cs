using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryUI : MonoBehaviour
{
    public TMP_Text score;
    private TaskChecker taskChecker;
    private HighScoreManager highScoreManager;

    // Start is called before the first frame update
    void Start()
    {
        taskChecker = GameObject.FindObjectOfType<TaskChecker>();
        highScoreManager = GameObject.FindObjectOfType<HighScoreManager>();
        if (taskChecker)
        {
            if (highScoreManager)
            {
                if (highScoreManager.UpdateHighScore(taskChecker.currentScore))
                {
                    Debug.Log("New Highscore");
                    score.text = $"NEW HIGHSCORE!\n\nScore: {taskChecker.currentScore}";

                } else
                {
                    score.text = $"Game Over!\n\nScore: {taskChecker.currentScore}";
                }
            }
        } else
        {
            score.text = "No Score found";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartGame()
    {
        Debug.Log("Loading Main Menu");
        Destroy(taskChecker.gameObject);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
