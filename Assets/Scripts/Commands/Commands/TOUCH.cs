using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOUCH : BaseCommand
{
    public override string OnCommand(string[] args)
    {
        string output = "";

        if (args.Length <= 1)
        {
            return "touch: missing operand";
        }

        fileSystem.CreateFile(args[1]);

        return output;
    }
}