using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FileSystem : MonoBehaviour
{
    private Folder root = new Folder("root", null);
    private Folder currentFolder;

    private void Start()
    {
        SetCurrentFolder(root);

        //Testing (Creating folders)
        CreateFolder("TestFolder1");
        Folder folder1 = (Folder)currentFolder.children[0];
        SetCurrentFolder(folder1);
        CreateFolder("TestFolder2");
        Folder folder2 = (Folder)currentFolder.children[0];
        SetCurrentFolder(folder2);
        CreateFolder("TestFolder3");
        Folder folder3 = (Folder)currentFolder.children[0];
        SetCurrentFolder(folder3);
        
        //Testing (Path from root to current folder)
        Debug.Log(GetCurrentPath());

        //Testing (Deleting folders)
        SetCurrentFolder(root);
        DeleteNode(root.children[0]);
        Debug.Log("After deletion: " + GetCurrentPath());
    }

    /// <summary>
    /// Set the current folder
    /// </summary>
    public void SetCurrentFolder(Folder folder)
    {
        if (folder != null)
        {
            currentFolder = folder;
        } else
        {
            Debug.Log("folder is NULL");
        }
    }
    
    /// <summary>
    /// Returns the current path from the root to the current folder
    /// </summary>
    public string GetCurrentPath()
    {
        List<string> paths = new List<string>();
        Folder currentDirectory = currentFolder;
        while (currentDirectory != root)
        {
            paths.Add(currentDirectory.name);
            currentDirectory = currentDirectory.parentFolder;
        }
        paths.Add(root.name);
        paths.Reverse();
        string pathString = "";
        foreach (string path in paths)
        {
            pathString += "/" + path;
        }
        return pathString;
    }

    /// <summary>
    /// Creates a folder as a child of the current folder
    /// </summary>
    public void CreateFolder(string folderName)
    {
        Folder NewFolder = new Folder(folderName, currentFolder);
        currentFolder.children.Add(NewFolder);
    }

    /// <summary>
    /// Creates a file as a child of the current folder
    /// </summary>
    public void CreateFile(string fileName)
    {
        File NewFile = new File(fileName);
        currentFolder.children.Add(NewFile);
    }

    public void RenameNode(BaseNode nodeToRename, string newName)
    {
        nodeToRename.Rename(newName);
    }

    /// <summary>
    /// Deletes the given node if it is a child of the current folder
    /// </summary>
    public void DeleteNode(BaseNode nodeToDelete)
    {
        if (nodeToDelete != null)
        {
            currentFolder.children.Remove(nodeToDelete);
        }
        else
        {
            Debug.Log("nodeToDelete is NULL");
        }
    }

}
