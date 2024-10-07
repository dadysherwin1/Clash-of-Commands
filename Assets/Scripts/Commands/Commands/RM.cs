using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RM : BaseCommand
{
    public override string OnCommand(string[] args)
    {
        string output = "";

        if (args.Length <= 1)
        {
            return "rm: missing operand";
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

                    File file = node as File;
                    if (file != null)
                    {
                        fileSystem.DeleteNode(node);
                        break;
                    }
                    else
                    {
                        output += "rm: cannot remove '" + arg + "': Is a directory\n";
                        break;
                    }   
                }
            }

            if (!isDeleted)
            {
                output += "rm: cannot remove '" + arg + "': No such file or directory\n";
            }
        }
        
        return output;
    }
}
