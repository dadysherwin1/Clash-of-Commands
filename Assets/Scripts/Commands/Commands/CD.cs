using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CD : BaseCommand
{
    public TerminalUI TerminalUI;
    public FileSystem FileSystem;

    private void Start()
    {
        TerminalUI = GameObject.FindObjectOfType<TerminalUI>();
        FileSystem = GameObject.FindObjectOfType<FileSystem>();
    }
    public override string OnCommand(string[] args)
    {
        string output = "";

        if (args.Length <= 1)
            return "";
        
        string target = args[1];
        Folder folder = fileSystem.GetCurrentFolder();
        if (target.Equals("..")) // go up one directory
        {
            Folder newFolder = folder.parentFolder;
            fileSystem.SetCurrentFolder(newFolder);
            TerminalUI.SetDirectory(FileSystem.GetCurrentPath());
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
                        TerminalUI.SetDirectory(FileSystem.GetCurrentPath());
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