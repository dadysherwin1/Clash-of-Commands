using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCommand : MonoBehaviour
{
    protected FileSystem fileSystem;

    public abstract string OnCommand(string[] args);

    private void Start()
    {
        fileSystem = GameObject.FindObjectOfType<FileSystem>();
    }
}
