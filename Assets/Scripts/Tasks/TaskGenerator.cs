using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

public class TaskGenerator
{
    private List<string> easyCommandTypes;
    private List<string> normalCommandTypes;
    private List<string> hardCommandTypes;
    private readonly List<string> allEasyCommands = new List<string>
    {
        "pwd", "mkdir", "rmdir", "cd", "echo", "ls", "rm", "touch"
    };
    private readonly List<string> allNormalCommands = new List<string>
    {
        "mkdir", "rmdir", "cd", "rm", "touch"
    };
    private readonly List<string> allHardCommands = new List<string>
    {
        "rm", "chmod ugo+rwx", "chmod ugo-rwx", "touch"
    };

    public TaskGenerator()
    {
        ResetEasyCommands();
        ResetNormalCommands();
    }

    // Generate a list of tasks given a size and return the list
    public List<Task> GenerateTaskList()
    {
        int listSize = 14;
        List<Task> taskList = new List<Task>();
        // Generate easy questions
        for (int i = 0; i < 5; i++)
        {
            string commandType = GetRandomEasyCommand();
            Task newTask = new Task(commandType, 1);
            taskList.Add(newTask);
        }
        //Generate medium questions
        for (int i = 5; i < 10; i++)
        {
            string commandType = GetRandomNormalCommand();
            Task newTask = new Task(commandType, 2);
            taskList.Add(newTask);
        }
        //Generate hard questions
        for (int i = 10; i < 14; i++)
        {
            string commandType = GetRandomHardCommand();
            Task newTask = new Task(commandType, 3);
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

    public string GetRandomHardCommand()
    {
        // If all commands have been used, reset the command list
        if (normalCommandTypes.Count == 0)
        {
            ResetHardCommands();
        }

        // Select a random command and remove it from the list
        int index = Random.Range(0, hardCommandTypes.Count);
        string selectedCommand = hardCommandTypes[index];
        hardCommandTypes.RemoveAt(index);

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

    public void ResetHardCommands()
    {
        // Copy allCommands into commandTypes to reset it
        hardCommandTypes = new List<string>(allHardCommands);
    }

}
