using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMDIR : BaseCommand
{
    public override string OnCommand(string[] args)
    {
        string output = "";

        if (args.Length <= 1)
        {
            return "rmdir: missing operand";
        }

        for (int i = 1; i < args.Length; i++)
        {
            string arg = args[i];
            bool isDeleted = false;
            Folder folder = fileSystem.GetCurrentFolder();
            foreach (BaseNode node in folder.children)
            {
                if (node.name == arg)
                {
                    isDeleted = true;

                    Folder childFolder = node as Folder;
                    if (childFolder != null)
                    {
                        fileSystem.DeleteNode(node);
                        break;
                    }
                    else
                    {
                        output += "rmdir: failed to remove '" + arg + "': Not a directory\n";
                        break;
                    }   
                }
            }

            if (!isDeleted)
            {
                output += "rmdir: failed to remove '" + arg + "': No such file or directory\n";
            }
        }
        
        return output;
    }
}