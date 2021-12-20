using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundSound : MonoBehaviour
{
    public static AudioClip backgroundMusicDesert, backgroundMusicForest, BackgroundMusicMoon;
    static AudioSource audioSrc;
    static int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        audioSrc = GetComponent<AudioSource>();
        backgroundMusicForest = Resources.Load<AudioClip>("backgroundMusic-forest");
        backgroundMusicDesert = Resources.Load<AudioClip>("backgroundMusic-desert");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound()
    {
        if (currentLevel == 2 || currentLevel == 4)
        {
            audioSrc.clip = backgroundMusicForest;
        }
        else if (currentLevel == 6 || currentLevel == 8)
        {
            audioSrc.clip = backgroundMusicDesert;
        }
        else if (currentLevel == 10)
        {
            audioSrc.clip = backgroundMusicDesert;
        }
        audioSrc.loop = true;
        audioSrc.Play();
    }
    public static void StopSound()
    {
        audioSrc.Stop();
    }
}
