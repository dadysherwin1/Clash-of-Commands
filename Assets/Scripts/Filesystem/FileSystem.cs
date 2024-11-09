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
    }

    /// <summary>
    /// Resets the file system to its default state.
    /// Clears existing nodes and re-initializes the root and current folder.
    /// </summary>
    public void ResetFileSystem(List<string> newFolders, List<string> newFiles)
    {
        root = new Folder("root", null);
        SetCurrentFolder(root);

        // Create required folder structure
        foreach (string folderPath in newFolders)
        {
            CreateNestedFolderStructure(folderPath);
        }

        // Create required files in their specified folders
        foreach (string filePath in newFiles)
        {
            string directoryPath = System.IO.Path.GetDirectoryName(filePath);
            string fileName = System.IO.Path.GetFileName(filePath);

            // Navigate to or create the required directory
            Folder targetFolder = NavigateOrCreateFolderPath(directoryPath);
            SetCurrentFolder(targetFolder);

            // Create the file     
            CreateFile(fileName);
            SetCurrentFolder(root);
        }

        AddRandomFilesFolders();
    }

    private void CreateNestedFolderStructure(string folderPath)
    {
        // Split the path to create nested folders one by one
        string[] folderNames = folderPath.Split('/');
        Folder current = root;

        foreach (string folderName in folderNames)
        {
            Folder existingFolder = current.children.Find(f => f is Folder && f.name == folderName) as Folder;

            if (existingFolder == null)
            {
                Folder newFolder = new Folder(folderName, current);
                current.children.Add(newFolder);
                current = newFolder;
            }
            else
            {
                current = existingFolder; // Move to the existing folder
            }
        }
    }

    // Helper method to navigate or create the folder structure based on a path
    private Folder NavigateOrCreateFolderPath(string folderPath)
    {
        Folder current = root;

        if (!string.IsNullOrEmpty(folderPath))
        {
            string[] folders = folderPath.Split('/');

            foreach (string folderName in folders)
            {
                Folder nextFolder = current.children.Find(f => f is Folder && f.name == folderName) as Folder;

                if (nextFolder == null)
                {
                    nextFolder = new Folder(folderName, current);
                    current.children.Add(nextFolder);
                }

                current = nextFolder;
            }
        }

        return current;
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
    /// Get the current folder
    /// </summary>
    public Folder GetCurrentFolder()
    {
        return currentFolder;
    }

    /// <summary>
    /// Get the root folder
    /// </summary>
    public Folder GetRootFolder()
    {
        return root;
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
        
    public void AddRandomFilesFolders()
    {
        WordGenerator generator = new WordGenerator();
        CreateFolder(generator.GetRandomFolderName());
        CreateFile(generator.GetRandomFileName()+generator.GetRandomFileExtension());
    }

}
