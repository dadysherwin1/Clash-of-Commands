using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folder : BaseNode
{
    public List<BaseNode> children;

    public Folder(string folderName, Folder parent)
    {
        name = folderName;
        children = new List<BaseNode>();
        parentFolder = parent;
    }

}
