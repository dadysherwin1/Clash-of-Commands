using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryUI : MonoBehaviour
{
    public TMP_Text textBox;
    private TaskChecker taskChecker;

    // Start is called before the first frame update
    void Start()
    {
        taskChecker = GameObject.FindObjectOfType<TaskChecker>();
        if (taskChecker)
        {
            textBox.text = $"Game Over!\n\nScore: {taskChecker.currentScore}";
        } else
        {
            textBox.text = "No Score found";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
