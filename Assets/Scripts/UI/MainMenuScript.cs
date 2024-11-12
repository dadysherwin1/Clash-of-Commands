using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public TMP_Text HighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        HighScoreManager highScoreManager = GameObject.FindObjectOfType<HighScoreManager>();
        HighScoreText.text = $"HIGHSCORE: {highScoreManager.highscore}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("TerminalScene");
    }
}
