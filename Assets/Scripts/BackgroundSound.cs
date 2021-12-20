using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundSound : MonoBehaviour
{
    public static AudioClip backgroundMusicDesert, backgroundMusicForest, backgroundMusicMoon, menuMusic;
    static AudioSource audioSrc;
    static int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        audioSrc = GetComponent<AudioSource>();
        backgroundMusicForest = Resources.Load<AudioClip>("backgroundMusic-forest");
        backgroundMusicDesert = Resources.Load<AudioClip>("backgroundMusic-desert");
        backgroundMusicMoon = Resources.Load<AudioClip>("backgroundMusic-moon");
        menuMusic = Resources.Load<AudioClip>("menuMusic");
        
    }
    // Update is called once per frame
    void Update()
    {
        if (menuMusic.loadState == AudioDataLoadState.Loaded && backgroundMusicDesert.loadState == AudioDataLoadState.Loaded
            && backgroundMusicForest.loadState == AudioDataLoadState.Loaded && backgroundMusicMoon.loadState == AudioDataLoadState.Loaded && !audioSrc.isPlaying)
        {
            PlaySound();
        }
    }

    public static void PlaySound()
    {
        if (currentLevel == 0)
        {
            audioSrc.clip = menuMusic;
        }
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
            audioSrc.clip = backgroundMusicMoon;
        }
        audioSrc.loop = true;
        audioSrc.Play();
    }
    public static void StopSound()
    {
        if (currentLevel == 0)
        {
            audioSrc.clip = menuMusic;
        }
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
            audioSrc.clip = backgroundMusicMoon;
        }
        audioSrc.Stop();
    }
}
