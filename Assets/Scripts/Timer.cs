using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    [HideInInspector] public float startTime;
    bool IsRunning = false;
    public TextMeshProUGUI textMeshPro;
    int currentLevel;



    void Start()
    {
        startTime = timeRemaining;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        IsRunning = true;
    }

    void Update()
    {
        if (IsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                IsRunning = false;
                PlayerPrefs.SetInt("levelToRestart", currentLevel);
                BackgroundSound.StopSound();
                SceneManager.LoadScene(13);
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        textMeshPro.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

