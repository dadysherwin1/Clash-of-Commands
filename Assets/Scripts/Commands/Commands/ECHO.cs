using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECHO : BaseCommand
{
    public override string OnCommand(string[] args)
    {
        string output = "";

        for (int i = 1; i < args.Length; i++)
        {
            if (i > 1)
                output += " ";
            output += args[i];
        }

        return output;
    }
}
