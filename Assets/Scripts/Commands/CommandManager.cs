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
    private CHMOD chmod;
    private FileSystem fileSystem;
    private TaskChecker taskChecker;
    private TerminalUI terminalUI;
    public AudioManager audioManager;

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
        chmod = GetComponent<CHMOD>();
        fileSystem = GameObject.FindObjectOfType<FileSystem>();
        taskChecker = GameObject.FindObjectOfType<TaskChecker>();
        terminalUI = GameObject.FindObjectOfType<TerminalUI>();
    }

    public void OnCommandEntered(string input)
    {
        string[] args = input.Split(" ");
        if (args.Length <= 0) return;
        
        switch (args[0])
        {
            case "ls":
                terminalUI.AddResponseLines(ls.OnCommand(args));
                break;
            case "cd":
                terminalUI.AddResponseLines(cd.OnCommand(args));
                break;
            case "pwd":
                terminalUI.AddResponseLines(pwd.OnCommand(args));
                break;
            case "touch":
                terminalUI.AddResponseLines(touch.OnCommand(args));
                break;
            case "echo":
                terminalUI.AddResponseLines(echo.OnCommand(args));
                break;
            case "rm":
                terminalUI.AddResponseLines(rm.OnCommand(args));
                break;
            case "mkdir":
                terminalUI.AddResponseLines(mkdir.OnCommand(args));
                break;
            case "rmdir":
                terminalUI.AddResponseLines(rmdir.OnCommand(args));
                break;
            case "chmod":
                terminalUI.AddResponseLines(chmod.OnCommand(args));
                break;
            default:
                // print invalid command entered
                terminalUI.AddResponseLines("bash: " + args[0] + ": command not found");
                //audioManager.PlayError();
                break;
        }

        taskChecker.CheckTask(input, fileSystem.GetCurrentPath());
    }
}
