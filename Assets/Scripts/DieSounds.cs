using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSounds : MonoBehaviour
{
    public GameObject gameOverScreen;
    public AudioSource[] audioSources;
    private bool hasPlayedAudio1 = false;
    private bool hasPlayedAudio2 = false;

    void Update()
    {
        if (gameOverScreen == true && hasPlayedAudio1 == false)
        {
            audioSources[0].Play();
            hasPlayedAudio1 = true;

        }

        if (gameOverScreen == true && hasPlayedAudio2 == false)
        {
            audioSources[1].Play();
            hasPlayedAudio2 = true;

        }
    }
}
