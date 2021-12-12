using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    bool IsRunning = false;
    public TextMeshProUGUI textMeshPro;


    void Start()
    {
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

