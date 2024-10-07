using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip correctSFX;
    public AudioClip errorSFX;
    public AudioClip victorySFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCorrect()
    {
        audioSource.PlayOneShot(correctSFX);
    }

    public void PlayError()
    {
        audioSource.PlayOneShot(errorSFX);
    }

    public void PlayVictory()
    {
        audioSource.PlayOneShot(victorySFX);
    }
}
