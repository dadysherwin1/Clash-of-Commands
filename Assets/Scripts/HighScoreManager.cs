using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public int highscore = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Prevents multiple managers persisting across multiple rounds
        HighScoreManager[] highScoreManagers = GameObject.FindObjectsOfType<HighScoreManager>();
        if (highScoreManagers.Length == 1)
        {
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool UpdateHighScore(int newScore)
    {
        if (newScore > highscore)
        {
            highscore = newScore;
            return true;
        }
        else
        {
            return false;
        }
    }
}
