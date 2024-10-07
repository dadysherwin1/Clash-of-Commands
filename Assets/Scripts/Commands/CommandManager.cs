using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private LS ls;
    private CD cd;
    private PWD pwd;
    private TOUCH touch;
    private ECHO echo;
    private RM rm;
    private MKDIR mkdir;
    private RMDIR rmdir;
    private FileSystem fileSystem;
    private TaskChecker taskChecker;

    private void Start()
    {
        ls = GetComponent<LS>();
        cd = GetComponent<CD>();
        pwd = GetComponent<PWD>();
        touch = GetComponent<TOUCH>();
        echo = GetComponent<ECHO>();
        rm = GetComponent<RM>();
        mkdir = GetComponent<MKDIR>();
        rmdir = GetComponent<RMDIR>();
        fileSystem = GameObject.FindObjectOfType<FileSystem>();
        taskChecker = GameObject.FindObjectOfType<TaskChecker>();
    }

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
            case "echo":
                Debug.Log(echo.OnCommand(args));
                break;
            case "rm":
                Debug.Log(rm.OnCommand(args));
                break;
            case "mkdir":
                Debug.Log(mkdir.OnCommand(args));
                break;
            case "rmdir":
                Debug.Log(rmdir.OnCommand(args));
                break;
            default:
                // print invalid command entered
                Debug.Log("bash: " + args[0] + ": command not found");
                break;
        }

        taskChecker.CheckTask(input, fileSystem.GetCurrentPath());
    }
}
