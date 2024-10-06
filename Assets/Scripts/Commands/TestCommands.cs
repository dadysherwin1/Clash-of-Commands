using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCommands : MonoBehaviour
{
    [SerializeField] CommandManager commandManager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LateStart(1));
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        Debug.Log("dylanka$ fuck");
        commandManager.OnCommandEntered("fuck");
        Debug.Log("dylanka$ touch miners");
        commandManager.OnCommandEntered("touch miners");
        Debug.Log("dylanka$ ls");
        commandManager.OnCommandEntered("ls");
        Debug.Log("dylanka$ cd miners");
        commandManager.OnCommandEntered("cd miners");
        Debug.Log("dylanka$ pwd");
        commandManager.OnCommandEntered("pwd");

        /*Debug.Log("");
        Debug.Log("");
        Debug.Log("");

        Debug.Log("dylanka$ cd ..");
        commandManager.OnCommandEntered("cd ..");
        Debug.Log("dylanka$ pwd");
        commandManager.OnCommandEntered("pwd");*/
    }
}
