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

        fileSystem.CreateFolder(args[1]);

        return output;
    }
}