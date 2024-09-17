using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class File : BaseNode
{
    public File(string fileName)
    {
        name = fileName;
    }

    public string content;
}
