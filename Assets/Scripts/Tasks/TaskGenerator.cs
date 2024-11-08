using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

public class TaskGenerator
{
    private List<string> easyCommandTypes;
    private List<string> normalCommandTypes;
    private readonly List<string> allEasyCommands = new List<string>
    {
        "pwd", "mkdir", "rmdir", "cd", "echo", "ls", "rm", "touch"
    };
    private readonly List<string> allNormalCommands = new List<string>
    {
        "mkdir", "rmdir", "cd", "rm", "touch"
    };

    public TaskGenerator()
    {
        ResetEasyCommands();
        ResetNormalCommands();
    }

    // Generate a list of tasks given a size and return the list
    public List<Task> GenerateTaskList(int listSize)
    {
        List<Task> taskList = new List<Task>();
        // Generate easy questions
        for (int i = 0; i < listSize / 2; i++)
        {
            string commandType = GetRandomEasyCommand();
            Task newTask = new Task(commandType, 1);
            taskList.Add(newTask);
        }
        //Generate medium questions
        for (int i = listSize / 2; i < listSize; i++)
        {
            string commandType = GetRandomNormalCommand();
            Task newTask = new Task(commandType, 2);
            taskList.Add(newTask);
        }
        return taskList;
    }

    // Get a random command type and remove it from the list
    public string GetRandomEasyCommand()
    {
        // If all commands have been used, reset the command list
        if (easyCommandTypes.Count == 0)
        {
            ResetEasyCommands();
        }

        // Select a random command and remove it from the list
        int index = Random.Range(0, easyCommandTypes.Count);
        string selectedCommand = easyCommandTypes[index];
        easyCommandTypes.RemoveAt(index);

        return selectedCommand;
    }

    public string GetRandomNormalCommand()
    {
        // If all commands have been used, reset the command list
        if (normalCommandTypes.Count == 0)
        {
            ResetNormalCommands();
        }

        // Select a random command and remove it from the list
        int index = Random.Range(0, normalCommandTypes.Count);
        string selectedCommand = normalCommandTypes[index];
        normalCommandTypes.RemoveAt(index);

        return selectedCommand;
    }

    public void ResetEasyCommands()
    {
        // Copy allCommands into commandTypes to reset it
        easyCommandTypes = new List<string>(allEasyCommands);
    }

    public void ResetNormalCommands()
    {
        // Copy allCommands into commandTypes to reset it
        normalCommandTypes = new List<string>(allNormalCommands);
    }

}
