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
    public TerminalUI TerminalUI;

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
        TerminalUI = GameObject.FindObjectOfType<TerminalUI>();
    }

    public void OnCommandEntered(string input)
    {
        string[] args = input.Split(" ");
        if (args.Length <= 0) return;
        
        switch (args[0])
        {
            case "ls":
                TerminalUI.AddResponseLines(ls.OnCommand(args));
                break;
            case "cd":
                TerminalUI.AddResponseLines(cd.OnCommand(args));
                break;
            case "pwd":
                TerminalUI.AddResponseLines(pwd.OnCommand(args));
                break;
            case "touch":
                TerminalUI.AddResponseLines(touch.OnCommand(args));
                break;
            case "echo":
                TerminalUI.AddResponseLines(echo.OnCommand(args));
                break;
            case "rm":
                TerminalUI.AddResponseLines(rm.OnCommand(args));
                break;
            case "mkdir":
                TerminalUI.AddResponseLines(mkdir.OnCommand(args));
                break;
            case "rmdir":
                TerminalUI.AddResponseLines(rmdir.OnCommand(args));
                break;
            default:
                // print invalid command entered
                Debug.Log("bash: " + args[0] + ": command not found");
                break;
        }

        taskChecker.CheckTask(input, fileSystem.GetCurrentPath());
    }
}
