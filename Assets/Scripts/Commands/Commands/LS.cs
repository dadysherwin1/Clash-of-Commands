using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LS : BaseCommand
{
    public override string OnCommand(string[] args)
    {
        string output = "";
        bool allFlag = false;

        if (args.Length >= 2)
        {
            if (args[1] == "-a" || args[1] == "--all")
            {
                allFlag = true;
                output += ". .. ";
            }
            else if (args[1] == "-A" || args[1] == "--almost-all")
            {
                allFlag = true;
            }
        }

        Folder folder = fileSystem.GetCurrentFolder();
        foreach (BaseNode node in folder.children)
        {
            if (node.isHidden && !allFlag) continue;
            output += node.name + " ";
        }

        return output;
    }
}