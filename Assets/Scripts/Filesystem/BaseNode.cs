using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNode
{
    public string name;
    public Folder parentFolder;
    public void Rename(string newName)
    {
        name = newName;
    }
}
