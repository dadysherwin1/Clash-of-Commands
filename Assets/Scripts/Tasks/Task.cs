using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public struct Task
{
    public string commandToRun;
    public string taskDescription;
    public string workingDirectory;         // task must be completed in this directory
    public List<string> requiredFiles;      // Construct a new file system with these files
    public List<string> requiredFolders;    // Construct a new file system with these folders

    /// <summary>
    /// Initialises a task given only the command type
    /// </summary>
    public Task(string command)
    {
        commandToRun = command;
        taskDescription = null;
        workingDirectory = null;
        requiredFiles = new List<string>();
        requiredFolders = new List<string>();
        GenerateEasyTask(command);
    }

    /// <summary>
    /// Generates task that can be done in 1 line. 
    /// </summary>
    public void GenerateEasyTask(string command)
    {
        WordGenerator generator = new WordGenerator();
        string fileName = generator.GetRandomFileName();
        string folderName = generator.GetRandomFileName();
        string fileType = generator.GetRandomFileExtension();
        switch (command)
        {
            case "pwd":
                taskDescription = "Find out what our current working directory is.";
                commandToRun = "pwd";
                workingDirectory = "";
                break;
            case "mkdir":
                taskDescription = "Create a folder called " + folderName + ".";
                commandToRun = "mkdir " + folderName;
                workingDirectory = "/root";
                break;
            case "rmdir":
                taskDescription = "Delete the " + folderName + " folder.";
                commandToRun = "rmdir " + folderName;
                workingDirectory = "/root";
                requiredFolders.Add(folderName);
                break;
            case "cd":
                taskDescription = "Navigate into the " + folderName + " folder.";
                commandToRun = "cd " + folderName;
                workingDirectory = "/root/" + folderName;
                requiredFolders.Add(folderName);
                break;
            case "echo":
                taskDescription = "Print " + fileName + ".";
                commandToRun = "echo " + fileName;
                workingDirectory = "";
                break;
            case "ls":
                taskDescription = "Print the names of each file in the current directory";
                commandToRun = "ls";
                workingDirectory = "";
                break;
            case "rm":
                taskDescription = "Delete the file " + fileName + fileType;
                commandToRun = "rm " + fileName + fileType;
                workingDirectory = "/root";
                requiredFiles.Add(fileName + fileType);
                break;
            case "touch":              
                taskDescription = "Create a file called " + fileName + fileType;
                commandToRun = "touch " + fileName + fileType;
                workingDirectory = "/root";
                requiredFiles.Add(fileName + fileType);
                break;             
            default:
                taskDescription = "Task Description ERROR";
                break;
        }
    }

    public void GenerateMediumTask(string command)
    {
        WordGenerator generator = new WordGenerator();
        string fileName = generator.GetRandomFileName();
        string folderName = generator.GetRandomFileName();
        string fileType = generator.GetRandomFileExtension();
        switch (command)
        {
            case "pwd":
                taskDescription = "Find out what our current working directory is.";
                commandToRun = "pwd";
                workingDirectory = "";
                break;
            case "mkdir":
                taskDescription = "Create a folder called " + folderName + ".";
                commandToRun = "mkdir " + folderName;
                workingDirectory = "/root";
                break;
            case "rmdir":
                taskDescription = "Delete the " + folderName + " folder.";
                commandToRun = "rmdir " + folderName;
                workingDirectory = "/root";
                requiredFolders.Add(folderName);
                break;
            case "cd":
                taskDescription = "Navigate into the " + folderName + " folder.";
                commandToRun = "cd " + folderName;
                workingDirectory = "/root/" + folderName;
                requiredFolders.Add(folderName);
                break;
            case "echo":
                taskDescription = "Print " + fileName + ".";
                commandToRun = "echo " + fileName;
                workingDirectory = "";
                break;
            case "ls":
                taskDescription = "Print the names of each file in the current directory";
                commandToRun = "ls";
                workingDirectory = "";
                break;
            case "rm":
                taskDescription = "Delete the file " + fileName + fileType;
                commandToRun = "rm " + fileName + fileType;
                workingDirectory = "/root";
                requiredFiles.Add(fileName + fileType);
                break;
            case "touch":
                taskDescription = "Create a file called " + fileName + fileType;
                commandToRun = "touch " + fileName + fileType;
                workingDirectory = "/root";
                requiredFiles.Add(fileName + fileType);
                break;
            default:
                taskDescription = "Task Description ERROR";
                break;
        }
    }

}
