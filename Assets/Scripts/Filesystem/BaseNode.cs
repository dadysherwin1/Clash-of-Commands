using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNode
{
    public string name;
    public Folder parentFolder;
    public bool[] permissions = {
        true, true, false, // users read write exec
        true, false, false, // group read write exec
        true, false, false // other read write exec
    };

    public bool isHidden
    {
        get { return name[0] == '.'; }
        set { name = "." + name; }
    }

    public void Rename(string newName)
    {
        name = newName;
    }
}
