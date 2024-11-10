using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CD : BaseCommand
{
    public override string OnCommand(string[] args)
    {

        if (args.Length <= 1)
            return "";
        if (args.Length >= 3)
            return "bash: cd: too many arguments";

        string target = args[1];
        Folder folder = fileSystem.GetCurrentFolder();
        if (target.Equals("..")) // go up one directory
        {
            Folder newFolder = folder.parentFolder;
            fileSystem.SetCurrentFolder(newFolder);
            terminalUI.UpdateUserInputLine();
            return "";
        }
        else if (target.Equals("/"))
        {
            Folder newFolder = fileSystem.GetRootFolder();
            fileSystem.SetCurrentFolder(newFolder);
            terminalUI.UpdateUserInputLine();
            return "";
        }
        else // go to child folder
        {
            foreach (BaseNode childNode in folder.children)
            {
                if (childNode.name == target)
                {
                    Folder childFolder = childNode as Folder;
                    if (childFolder != null)
                    {
                        fileSystem.SetCurrentFolder(childFolder);
                        terminalUI.UpdateUserInputLine();
                        return "";
                    }
                    else
                    {
                        // THATS A FILE NOT A FOLDER!
                        return "bash: cd: " + target + ": Not a directory";
                    }
                }
            }
        }

        return "bash: cd: " + target + ": No such file or directory";
    }
}