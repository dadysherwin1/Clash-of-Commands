using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public struct Task
{
    public string commandToRun;
    public int pointValue;
    public string taskDescription;
    public string workingDirectory;         // task must be completed in this directory
    public List<string> requiredFiles;      // Construct a new file system with these files
    public List<string> requiredFolders;    // Construct a new file system with these folders

    /// <summary>
    /// Initialises a task given only the command type
    /// </summary>
    public Task(string command, int value)
    {
        commandToRun = command;
        pointValue = value;
        taskDescription = null;
        workingDirectory = null;
        requiredFiles = new List<string>();
        requiredFolders = new List<string>();
        switch (value) {
            case 1:
                GenerateEasyTask(command);
                break;
            case 2:
                GenerateMediumTask(command);
                break;
            case 3:
                GenerateHardtask(command);
                break;
        }     
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

    //"mkdir", "rmdir", "cd", "rm", "touch"
    public void GenerateMediumTask(string command)
    {
        WordGenerator generator = new WordGenerator();
        string fileName = generator.GetRandomFileName();
        string folderName1 = generator.GetRandomFileName();
        string folderName2 = generator.GetRandomFileName();
        string fileType = generator.GetRandomFileExtension();
        string nestedFolderPath = folderName2 + "/" + folderName1;

        switch (command)
        {
            case "mkdir":
                taskDescription = $"Create a folder called {folderName1} in the {folderName2} folder.";
                commandToRun = $"mkdir {folderName1}";
                workingDirectory = "/root/" + folderName2;
                requiredFolders.Add(folderName2);
                break;
            case "rmdir":
                taskDescription = $"Delete the {folderName1} folder in the {folderName2} folder.";
                commandToRun = $"rmdir {folderName1}";
                workingDirectory = "/root/" + folderName2;
                requiredFolders.Add(nestedFolderPath);
                break;
            case "cd":
                taskDescription = $"Find the {folderName1} folder in the {folderName2} folder and navigate into it.";
                commandToRun = $"cd {folderName1}";
                workingDirectory = "/root/" + nestedFolderPath;
                requiredFolders.Add(nestedFolderPath);
                break;
            case "rm":
                taskDescription = $"Delete the file {fileName}{fileType} in the {folderName1} folder.";
                commandToRun = $"rm {fileName}{fileType}";
                workingDirectory = "/root/" + folderName1;
                requiredFiles.Add(folderName1 + "/" + fileName + fileType);
                requiredFolders.Add(folderName1);
                break;
            case "touch":
                taskDescription = $"Create a file called {fileName}{fileType} in the {folderName1} folder.";
                commandToRun = $"touch {fileName}{fileType}";
                workingDirectory = "/root/" + folderName1;
                requiredFolders.Add(folderName1);
                break;
            default:
                taskDescription = "TASK DESCRIPTION ERROR";
                break;
        }
    }

    //"rm", "chmod ugo+rwx", "chmod ugo-rwx", "touch"
    public void GenerateHardtask(string command)
    {
        WordGenerator generator = new WordGenerator();
        string fileName = generator.GetRandomFileName();
        string folderName1 = generator.GetRandomFileName();
        string folderName2 = generator.GetRandomFileName();
        string fileType = generator.GetRandomFileExtension();
        string nestedFolderPath = folderName2 + "/" + folderName1;

        switch (command)
        {
            case "rm":
                taskDescription = "Delete the hidden file in the current directory.";
                commandToRun = $"rm .{fileName}{fileType}";
                workingDirectory = "/root";
                requiredFiles.Add($".{fileName}{fileType}");
                break;
            case "chmod ugo+rwx":
                taskDescription = $"Allow anyone to read, write, & execute {fileName}{fileType}";
                commandToRun = $"chmod ugo+rwx {fileName}{fileType}";
                workingDirectory = "/root";
                requiredFiles.Add($"{fileName}{fileType}");
                break;
            case "chmod ugo-rwx":
                taskDescription = $"Remove all read, write, & execute permissions for everyone on {fileName}{fileType}";
                commandToRun = $"chmod ugo-rwx {fileName}{fileType}";
                workingDirectory = "/root";
                requiredFiles.Add($"{fileName}{fileType}");
                break;
            case "touch":
                taskDescription = $"Create a hidden file called .{fileName}{fileType} in the current directory.";
                commandToRun = $"touch .{fileName}{fileType}";
                workingDirectory = "/root";
                break;
            default:
                taskDescription = "TASK DESCRIPTION ERROR";
                break;
        }
    }


}
