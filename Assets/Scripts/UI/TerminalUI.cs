using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.EventSystems;
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

    public GameObject hard;
    public GameObject medium;
    public GameObject easy;

    private int lines = 1;

    private bool open;
    public List<GameObject> allObjects = new List<GameObject>();

    private CommandManager commandManager;

    private void Start()
    {
        commandManager = FindObjectOfType<CommandManager>();
        startLocation = directoryprefab.GetComponentsInChildren<TMP_Text>()[0].text;
        currentLocation = startLocation;
        fileSystem = FindObjectOfType<FileSystem>();
        open = true;
        // Set the input field as selected
        EventSystem.current.SetSelectedGameObject(inputfield.gameObject);
        inputfield.OnPointerClick(new PointerEventData(EventSystem.current));
        lines = 1;
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
        string place = "player1@pc " + fileSystem.GetCurrentPath() + " $";
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
        allObjects.Add(message);
        message.GetComponentsInChildren<TMP_Text>()[1].text = userInput;
        string place = "player1@pc " + fileSystem.GetCurrentPath() + " $";
        message.GetComponentsInChildren<TMP_Text>()[0].text = place;
        int characterCount = place.Length;
        float newWidth = characterCount * 13;
        message.GetComponentsInChildren<TMP_Text>()[0].rectTransform.sizeDelta = new Vector2(newWidth, message.GetComponentsInChildren<TMP_Text>()[0].rectTransform.sizeDelta.y);
    }

    // Update is called once per frame
    public void AddLines(int amount)
    {
        lines += amount;
    }

    public void AddResponseLines(string input)
    {
        if (input.Equals("")) return;

        GameObject message = Instantiate(responseprefab, commandLineContainer.transform);
        message.transform.SetAsLastSibling();
        message.GetComponent<RectTransform>().sizeDelta = new Vector2(message.GetComponent<RectTransform>().sizeDelta.x, 35 * lines);
        message.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(message.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x, 35 * lines);
        allObjects.Add(message);

        Vector2 containerSize = commandLineContainer.GetComponent<RectTransform>().sizeDelta;
        commandLineContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(containerSize.x, containerSize.y + 35.0f);

        message.GetComponentInChildren<TMP_Text>().text = input;
        lines = 1;
    }

    public void ClearScreen()
    {
        foreach (GameObject gameObject in allObjects)
        {
            Destroy(gameObject);
        }
        allObjects.Clear();
    }

    public void UpdateDifficulty(int difficulty)
    {
        hard.SetActive(false);
        medium.SetActive(false);
        easy.SetActive(false);

        if (difficulty == 3)
        {
            hard.SetActive(true);
        }
        else if (difficulty == 2)
        {
            medium.SetActive(true);
        }
        else if (difficulty == 1)
        {
            easy.SetActive(true);
        }
    }
}
