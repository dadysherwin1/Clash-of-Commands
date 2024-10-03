using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TerminalUI : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text Terminal;
    void Start()
    {
        
    }

    // Update is called once per frame
    

    void OnCommandEntered(string entry)
    {
        entry = entry.ToLower();
        string[] array = entry.Split(' ');
        string command = array[0];
        string action = "";
        for (int i = 1; i < array.Length; i++)
        {
            action += array[i];
        }

        if (command == "ls")
        {
            //LSCommand.OnCommand(action);
        }
        else if (command == "cd")
        {
            //CDCommand.OnCommand(action);
        }
        else if (command == "touch")
        {
            //TOUCHCommand.OnCommand(action);
        }
        else if (command == "echo")
        {
            //ECHOCommand.OnCommand(action);
        }
        else if (command == "rm")
        {
            //RMCommand.OnCommand(action);
        }
        else if (command == "mkdir")
        {
            //MKDIRCommand.OnCommand(action);
        }
        else if (command == "rmdir")
        {
            //RMDIRCommand.OnCommand(action);
        }
    }

    void PrintLine(string line)
    {
        string print = "/n" + line;
        Terminal.text += print;
    }

    void Update()
    {
        #region ALPHABET
        if (Input.GetKeyDown(KeyCode.A)) { Terminal.text += "a"; }
        else if (Input.GetKeyDown(KeyCode.B)) { Terminal.text += "b"; }
        else if (Input.GetKeyDown(KeyCode.C)) { Terminal.text += "c"; }
        else if (Input.GetKeyDown(KeyCode.D)) { Terminal.text += "d"; }
        else if (Input.GetKeyDown(KeyCode.E)) { Terminal.text += "e"; }
        else if (Input.GetKeyDown(KeyCode.F)) { Terminal.text += "f"; }
        else if (Input.GetKeyDown(KeyCode.G)) { Terminal.text += "g"; }
        else if (Input.GetKeyDown(KeyCode.H)) { Terminal.text += "h"; }
        else if (Input.GetKeyDown(KeyCode.I)) { Terminal.text += "i"; }
        else if (Input.GetKeyDown(KeyCode.J)) { Terminal.text += "j"; }
        else if (Input.GetKeyDown(KeyCode.K)) { Terminal.text += "k"; }
        else if (Input.GetKeyDown(KeyCode.L)) { Terminal.text += "l"; }
        else if (Input.GetKeyDown(KeyCode.M)) { Terminal.text += "m"; }
        else if (Input.GetKeyDown(KeyCode.N)) { Terminal.text += "n"; }
        else if (Input.GetKeyDown(KeyCode.O)) { Terminal.text += "o"; }
        else if (Input.GetKeyDown(KeyCode.P)) { Terminal.text += "p"; }
        else if (Input.GetKeyDown(KeyCode.Q)) { Terminal.text += "q"; }
        else if (Input.GetKeyDown(KeyCode.R)) { Terminal.text += "r"; }
        else if (Input.GetKeyDown(KeyCode.S)) { Terminal.text += "s"; }
        else if (Input.GetKeyDown(KeyCode.T)) { Terminal.text += "t"; }
        else if (Input.GetKeyDown(KeyCode.U)) { Terminal.text += "u"; }
        else if (Input.GetKeyDown(KeyCode.V)) { Terminal.text += "v"; }
        else if (Input.GetKeyDown(KeyCode.W)) { Terminal.text += "w"; }
        else if (Input.GetKeyDown(KeyCode.X)) { Terminal.text += "x"; }
        else if (Input.GetKeyDown(KeyCode.Y)) { Terminal.text += "y"; }
        else if (Input.GetKeyDown(KeyCode.Z)) { Terminal.text += "z"; }
        else if (Input.GetKeyDown(KeyCode.Space)) { Terminal.text += " "; }
        #endregion
    }
}
