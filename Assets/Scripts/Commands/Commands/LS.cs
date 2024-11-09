using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LS : BaseCommand
{
    public override string OnCommand(string[] args)
    {
        string output = "";
        bool allFlag = false;
        bool longFlag = false;

        for (int i = 1; i < args.Length; i++)
        {
            string arg = args[i];
            if (arg == "-a" || arg == "--all")
            {
                allFlag = true;
                output += ".  ..  ";
            }
            else if (arg == "-A" || arg == "--almost-all")
            {
                allFlag = true;
            }
            else if (arg == "-l")
            {
                longFlag = true;
            }
        }


        Folder folder = fileSystem.GetCurrentFolder();
        foreach (BaseNode node in folder.children)
        {
            if (node.isHidden && !allFlag) continue;
            Folder isFolder = node as Folder;
            if (isFolder != null)
            {
                // its a folder
                if (longFlag)
                {
                    output += "d";
                    output += PermissionsToString(node.permissions);
                    output += " ";
                    output += "<b>" + node.name + "</b>";
                    output += "\n";
                }
                else
                {
                    output += "<b>" + node.name + "</b>";
                    output += "  ";
                }
            }
            else
            { 
                // its a file
                if (longFlag)
                {
                    output += "-";
                    output += PermissionsToString(node.permissions);
                    output += " ";
                    output += node.name;
                    output += "\n";
                }
                else
                {
                    output += node.name + "  ";
                    output += "  ";
                }
                
            }
           
        }

        return output;
    }

    string PermissionsToString(bool[] permissions)
    {
        string output = "";
        for (int i = 0; i < 3; i++)
        {
            if (permissions[i*3])
                output += "r";
            else
                output += "-";
            if (permissions[i*3+1])
                output += "w";
            else
                output += "-";
            if (permissions[i*3+2])
                output += "x";
            else
                output += "-";
        }
        return output;
    }
}