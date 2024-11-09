using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCommands : MonoBehaviour
{
    [SerializeField] CommandManager commandManager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RunAllTasks());
    }

    // Coroutine to execute commands with a delay between them
    IEnumerator RunAllTasks()
    {
        for (int i = 0; i < testCommands.Length; i++)
        {
            yield return new WaitForSeconds(1f);

            Debug.Log("player1@pc $ " + testCommands[i]);
            commandManager.OnCommandEntered(testCommands[i]);
        }
    }

    string[] testCommands = {
        "pwd",
        "mkdir miners",
        "cd miners",
        "touch file.txt",
        "echo rush",
        "ls",
        "rm file.txt",
        "cd ..",     // Need to go back to root before deleting the miners folder
        "rmdir miners"
    };
}
