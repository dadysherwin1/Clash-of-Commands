using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using static UnityEngine.EventSystems.EventTrigger;

public class TerminalUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject directoryprefab;
    public GameObject responseprefab;
    public TMP_InputField inputfield;
    public GameObject userInputLine;
    public ScrollRect scroll;
    public GameObject commandLineContainer;
    public string startLocation;
    public string currentLocation;
    private FileSystem fileSystem;
    public GameObject cheatSheet;
    private bool open;

    private CommandManager commandManager;

    private void Start()
    {
        commandManager = FindObjectOfType<CommandManager>();
        startLocation = directoryprefab.GetComponentsInChildren<TMP_Text>()[0].text;
        currentLocation = startLocation;
        fileSystem = FindObjectOfType<FileSystem>();
        open = true;
    }

    private void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Return) && inputfield.isFocused && inputfield.text != "")
        {
            UpdateUserInputLine();
            string userInput = inputfield.text;
            inputfield.text = "";
            AddDirectoryLine(userInput);
            commandManager.OnCommandEntered(userInput);
            userInputLine.transform.SetAsLastSibling();
            inputfield.ActivateInputField();
            inputfield.Select();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!open)
            {
                cheatSheet.GetComponent<Animator>().Play("Open");
                open = true;
            }
            else
            {
                cheatSheet.GetComponent<Animator>().Play("Close");
                open = false;
            }
        }
    }

    public void UpdateUserInputLine()
    {
        string place = "dylanka@pc " + fileSystem.GetCurrentPath() + " $";
        userInputLine.GetComponentsInChildren<TMP_Text>()[0].text = place;
        int characterCount = place.Length;
        float newWidth = characterCount * 13;
        userInputLine.GetComponentsInChildren<TMP_Text>()[0].rectTransform.sizeDelta = new Vector2(newWidth, userInputLine.GetComponentsInChildren<TMP_Text>()[0].rectTransform.sizeDelta.y);
    }

    public void AddDirectoryLine(string userInput)
    {
        Vector2 containerSize = commandLineContainer.GetComponent<RectTransform>().sizeDelta;
        commandLineContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(containerSize.x, containerSize.y + 35.0f);

        GameObject message = Instantiate(directoryprefab, commandLineContainer.transform);
        message.transform.SetSiblingIndex(commandLineContainer.transform.childCount - 1);
        message.GetComponentsInChildren<TMP_Text>()[1].text = userInput;
        string place = "dylanka@pc " + fileSystem.GetCurrentPath() + " $";
        message.GetComponentsInChildren<TMP_Text>()[0].text = place;
        int characterCount = place.Length;
        float newWidth = characterCount * 13;
        message.GetComponentsInChildren<TMP_Text>()[0].rectTransform.sizeDelta = new Vector2(newWidth, message.GetComponentsInChildren<TMP_Text>()[0].rectTransform.sizeDelta.y);
    }

    // Update is called once per frame

    public void AddResponseLines(string input)
    {
        if (input.Equals("")) return;

        //for (int i = 0; i < inputs.Length; i++)
        //{
            GameObject message = Instantiate(responseprefab, commandLineContainer.transform);
            message.transform.SetAsLastSibling();

            Vector2 containerSize = commandLineContainer.GetComponent<RectTransform>().sizeDelta;
            commandLineContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(containerSize.x, containerSize.y + 35.0f);

            message.GetComponentInChildren<TMP_Text>().text = input;

        //}
    }
}
