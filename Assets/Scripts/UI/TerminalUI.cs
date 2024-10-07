using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TerminalUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject directoryprefab;
    public GameObject responseprefab;
    public TMP_InputField inputfield;
    public GameObject userInputLine;
    public ScrollRect scroll;
    public GameObject commandLineContainer;

   

    private void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Return) && inputfield.isFocused && inputfield.text != "")
        {
            string userInput = inputfield.text;
            inputfield.text = "";
            AddDirectoryLine(userInput);
            OnCommandEntered(userInput);
            userInputLine.transform.SetAsLastSibling();
            inputfield.ActivateInputField();
            inputfield.Select();
        }
    }

    public void AddDirectoryLine(string userInput)
    {
        Vector2 containerSize = commandLineContainer.GetComponent<RectTransform>().sizeDelta;
        commandLineContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(containerSize.x, containerSize.y + 100.0f);

        GameObject message = Instantiate(directoryprefab, commandLineContainer.transform);
        message.transform.SetSiblingIndex(commandLineContainer.transform.childCount - 1);
        message.GetComponentsInChildren<TMP_Text>()[1].text = userInput;
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

}
