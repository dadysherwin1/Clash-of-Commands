using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    [SerializeField] LS ls;
    [SerializeField] CD cd;
    [SerializeField] PWD pwd;
    [SerializeField] TOUCH touch;
    [SerializeField] FileSystem fileSystem;
    [SerializeField] TaskChecker taskChecker;

    public void OnCommandEntered(string input)
    {
        string[] args = input.Split(" ");
        if (args.Length <= 0) return;
        
        switch (args[0])
        {
            case "ls":
                Debug.Log(ls.OnCommand(args));
                break;
            case "cd":
                Debug.Log(cd.OnCommand(args));
                break;
            case "pwd":
                Debug.Log(pwd.OnCommand(args));
                break;
            case "touch":
                Debug.Log(touch.OnCommand(args));
                break;
            default:
                // print invalid command entered
                Debug.Log("bash: " + args[0] + ": command not found");
                break;
        }

        taskChecker.CheckTask(input, fileSystem.GetCurrentPath());
    }
}
