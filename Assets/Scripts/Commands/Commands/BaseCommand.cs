using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCommand : MonoBehaviour
{
    [SerializeField] protected FileSystem fileSystem;

    public abstract string OnCommand(string[] args);
}
