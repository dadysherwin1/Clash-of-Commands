using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

public class TaskGenerator
{
    private List<string> commandTypes;
    private readonly List<string> allCommands = new List<string>
    {
        "pwd", "mkdir", "rmdir", "cd", "echo", "ls", "rm", "touch"
    };

    public TaskGenerator()
    {
        ResetCommands();  // Initialize the command list
    }

    // Generate a list of tasks given a size and return the list
    public List<Task> GenerateTaskList(int listSize)
    {
        List<Task> taskList = new List<Task>();
        // Generate easy questions
        for (int i = 0; i < listSize / 2; i++)
        {
            string commandType = GetRandomCommandType();
            Task newTask = new Task(commandType, 1);
            taskList.Add(newTask);
        }
        //Generate medium questions
        for (int i = listSize / 2; i < listSize; i++)
        {
            string commandType = GetRandomCommandType();
            Task newTask = new Task(commandType, 2);
            taskList.Add(newTask);
        }
        return taskList;
    }

    // Get a random command type and remove it from the list
    public string GetRandomCommandType()
    {
        // If all commands have been used, reset the command list
        if (commandTypes.Count == 0)
        {
            ResetCommands();
        }

        // Select a random command and remove it from the list
        int index = Random.Range(0, commandTypes.Count);
        string selectedCommand = commandTypes[index];
        commandTypes.RemoveAt(index);

        return selectedCommand;
    }

    // Reset commandTypes list to contain all commands again
    public void ResetCommands()
    {
        // Copy allCommands into commandTypes to reset it
        commandTypes = new List<string>(allCommands);
    }

}
