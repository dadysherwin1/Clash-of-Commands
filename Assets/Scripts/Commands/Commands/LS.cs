using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LS : BaseCommand
{
    public override string OnCommand(string[] args)
    {
        string output = "";

        Folder folder = fileSystem.GetCurrentFolder();
        foreach (BaseNode node in folder.children)
        {
            output += node.name + ", ";
        }

        return output;
    }
}