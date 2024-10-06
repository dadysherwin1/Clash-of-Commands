using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWD : BaseCommand
{
    public override string OnCommand(string[] args)
    {
        string output = "";

        output += fileSystem.GetCurrentPath();

        return output;
    }
}
