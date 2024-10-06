using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Task
{
    public string taskDescription;
    public string commandToRun;
    public string workingDirectory;
    public Task(string description, string command, string directory)
    {
        taskDescription = description;
        commandToRun = command;
        workingDirectory = directory;
    }
}
