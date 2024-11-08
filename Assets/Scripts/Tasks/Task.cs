using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Task
{
    public string taskDescription;
    public string commandToRun;
    public string workingDirectory;
    public int pointValue;
    public Task(string description, string command, string directory, int value)
    {
        taskDescription = description;
        commandToRun = command;
        workingDirectory = directory;
        pointValue = value;
    }
}
