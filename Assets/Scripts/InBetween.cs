using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InBetween : MonoBehaviour
{
    public TextMeshProUGUI storyText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finishedTimeText;
    public TextMeshProUGUI nameLeft;
    public TextMeshProUGUI nameRight;
    private int whichAnt; // 0 Max 
    private int lineNumber = 0;
    string textToMain;
    public GameObject objectOne;
    public GameObject objectTwo;
    public GameObject objectThree;
    int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        objectOne.SetActive(false);
        objectTwo.SetActive(false);
        objectThree.SetActive(false);

        if (currentLevel != 0)
        {
            string finishedTime = PlayerPrefs.GetFloat("finishedTime").ToString("0.0");
            float scoreNumber = PlayerPrefs.GetFloat("timeRemaining") * 100;
            string scoreToString = scoreNumber.ToString("0");
            finishedTimeText.text = string.Format("TIME:" + finishedTime);
            scoreText.text = string.Format("SCORE:" + scoreToString);
        } 

        if (currentLevel == 0)
        {
            whichAnt = 1;
            ChangeText("PRIVATE MAX, I HAVE A MISSION FOR YOU!", whichAnt);
            lineNumber++;
        }

        if (currentLevel == 2)
        {
            whichAnt = 1;
            ChangeText("GOOD JOB, MAX!", whichAnt);
            lineNumber++;
        }

        if (currentLevel == 4)
        {
            whichAnt = 1;
            ChangeText("WELL DONE, MAX.", whichAnt);
            lineNumber++;
        }

        if (currentLevel == 6)
        {
            whichAnt = 1;
            ChangeText("GREAT JOB, MAX!", whichAnt);
            lineNumber++;
        }

        if (currentLevel == 8)
        {
            objectOne.SetActive(true);
            objectTwo.SetActive(true);
            objectThree.SetActive(true);
            whichAnt = 1;
            ChangeText("THANK YOU, MAX, FOR MY FLOWERS", whichAnt);
            lineNumber++;
        }

        if (currentLevel == 10)
        {
            whichAnt = 1;
            ChangeText("YOU HAVE DONE A GREAT JOB PREPARING OUR COLONY!", whichAnt);
            lineNumber++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (currentLevel == 0)
            {
                switch (lineNumber)
                {
                    case 1:
                        textToMain = "WHAT CAN I DO?";
                        whichAnt = 0;
                        break;
                    case 2:
                        textToMain = "YOU NEED TO BRING A BLUEBERRY FOR DINNER";
                        whichAnt = 1;
                        break;
                    case 3:
                        textToMain = "IT LOOKS LIKE THIS";
                        whichAnt = 1;
                        objectOne.SetActive(true);
                        break;
                    case 4:
                        textToMain = "I HOPE YOU DID NOT FORGET WHAT THE ANTHILL LOOKS LIKE";
                        whichAnt = 1;
                        break;
                    case 5:
                        textToMain = "*COUGH* IT IS ON MY RIGHT";
                        whichAnt = 1;
                        break;
                    case 6:
                        textToMain = "DO NOT FORGET, PRESS SPACE TO PICK UP ITEMS!";
                        whichAnt = 1;
                        break;
                    case 7:
                        textToMain = "YES SIR!";
                        whichAnt = 0;
                        break;
                    case 8:
                        SceneManager.LoadScene(currentLevel + 1);
                        break;
                }
            }
            if (currentLevel == 2)
            {
                switch (lineNumber)
                {
                    case 1:
                        textToMain = "BUT WE STILL NEED MORE STUFF";
                        whichAnt = 1;
                        break;
                    case 2:
                        textToMain = "NO PROBLEM. WHAT DO YOU NEED?";
                        whichAnt = 0;
                        break;
                    case 3:
                        textToMain = "YOU NEED TO BRING A LEAF, SAND AND ANOTHER BLUEBERRY";
                        whichAnt = 1;
                        break;
                    case 4:
                        textToMain = "DO YOU RECOGNISE THESE?";
                        whichAnt = 1;
                        objectOne.SetActive(true);
                        objectTwo.SetActive(true);
                        objectThree.SetActive(true);
                        break;
                    case 5:
                        textToMain = "YES! ROGER THAT!";
                        whichAnt = 0;
                        break;
                    case 6:
                        SceneManager.LoadScene(currentLevel + 1);
                        break;
                }
            }
            if (currentLevel == 4)
            {
                switch (lineNumber)
                {
                    case 1:
                        textToMain = "THAT WAS TOO EASY";
                        whichAnt = 0;
                        break;
                    case 2:
                        textToMain = "OH? YOU WANT A CHALLENGE?";
                        whichAnt = 1;
                        break;
                    case 3:
                        textToMain = "SURE!";
                        whichAnt = 0;
                        break;
                    case 4:
                        textToMain = "OK, GO TO THE DESERT, AND BRING BACK A BONE, FLOWER AND MORE SAND";
                        whichAnt = 1;
                        objectOne.SetActive(true);
                        objectTwo.SetActive(true);
                        objectThree.SetActive(true);
                        break;
                    case 5:
                        textToMain = "ON MY WAY!";
                        whichAnt = 0;
                        break;
                    case 6:
                        SceneManager.LoadScene(currentLevel + 1);
                        break;
                }
            }
            if (currentLevel == 6)
            {
                switch (lineNumber)
                {
                    case 1:
                        textToMain = "BUT NOW I NEED YOU TO GO BACK TO THE DESERT";
                        whichAnt = 1;
                        break;
                    case 2:
                        textToMain = "BUT I JUST GOT HOME!";
                        whichAnt = 0;
                    break;
                    case 3:
                        textToMain = "TONIGHT IS THE QUEEN’S BIRTHDAY PARTY";
                        whichAnt = 1;
                    break;
                    case 4:
                        textToMain = "I NEED YOU TO GO COLLECT THREE OF HER FAVORITE DESERT FLOWERS";
                        whichAnt = 1;
                    break;
                    case 5:
                        textToMain = "YOU REMEMBER THEM FROM YOUR LAST TRIP";
                        whichAnt = 1;
                        break;
                    case 6:
                        textToMain = "ANYTHING FOR MY QUEEN!";
                        whichAnt = 0;
                        break;
                    case 7:
                        SceneManager.LoadScene(currentLevel + 1);
                        break;
                    }
                }
            if (currentLevel == 8)
            {
                switch (lineNumber)
                {
                    case 1:
                        textToMain = "I’M HAPPY YOU LIKE THEM, MY QUEEN.";
                        whichAnt = 0;
                        break;
                    case 2:
                        textToMain = "YOU ARE A GOOD PRIVATE, I HAVE A MISSION FOR YOU.";
                        whichAnt = 1;
                        break;
                    case 3:
                        textToMain = "I WANT YOU TO GO AND PREPARE A NEW HOME FOR OUR COLONY";
                        whichAnt = 1;
                        break;
                    case 4:
                        textToMain = "WHERE?";
                        whichAnt = 0;
                        break;
                    case 5:
                        textToMain = "ON THE MOON.";
                        whichAnt = 1;
                        break;
                    case 6:
                        textToMain = "*AKWARD SILENCE*";
                        whichAnt = 2;
                        break;
                    case 7:
                        textToMain = "WE’LL BE EVERYWHERE!";
                        whichAnt = 0;
                        break;
                    case 8:
                        SceneManager.LoadScene(currentLevel + 1);
                        break;
                }
            }

            if (currentLevel == 10)
            {
                switch (lineNumber)
                {
                    case 1:
                        textToMain = "IT IS MY HONOR TO SERVE YOU";
                        whichAnt = 0;
                        break;
                    case 2:
                        textToMain = "FOR YOUR BRAVERY AND CONTRIBUTION TO THE COLONY";
                        whichAnt = 1;
                        break;
                    case 3:
                        textToMain = "YOU WILL BE AWARDED THE RANK OF LIEUTENANT";
                        whichAnt = 1;
                        objectOne.SetActive(true);
                        break;
                    case 4:
                        textToMain = "HORRAH!";
                        whichAnt = 0;
                        objectOne.SetActive(false);
                        objectTwo.SetActive(true);
                        break;
                    case 5:
                        textToMain = "CONGRATULATIONS LIEUTENANT MAX!";
                        whichAnt = 1;
                        break;
                    case 6:
                        SceneManager.LoadScene(currentLevel + 1);
                        break;
                }
            }
            lineNumber++;
            ChangeText(textToMain, whichAnt);
        }
    }

    void ChangeText(string text, int ant)
    {
        storyText.text = string.Format(text);

        switch (ant)
        {
            case 0:
                nameLeft.enabled = true;
                nameRight.enabled = false;
                break;
            case 1:
                nameLeft.enabled = false;
                nameRight.enabled = true;
                break;
            case 2:
                nameLeft.enabled = false;
                nameRight.enabled = false;
                break;
        }
    }

}
