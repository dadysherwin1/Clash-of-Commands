using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MKDIR : BaseCommand
{
    public override string OnCommand(string[] args)
    {
        string output = "";

        if (args.Length <= 1 ) {
            return "mkdir: missing operand";
        }

        for (int i = 1; i < args.Length; i++)
        {
            string arg = args[i];
            fileSystem.CreateFolder(arg);
        }

        return output;
    }
}