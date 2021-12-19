using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InBetween : MonoBehaviour
{
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI antName;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finishedTimeText;
    private int whichAnt; // 0 Max & 1 Bob
    private string[] antNames = { "MAX", "BOB", "QUEEN" };
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

        if(currentLevel != 0)
        {
            string finishedTime = PlayerPrefs.GetFloat("finishedTime").ToString("0.0");
            float scoreNumber = PlayerPrefs.GetFloat("timeRemaining") * 100;
            string scoreToString = scoreNumber.ToString("0");
            Debug.Log(scoreNumber);
            finishedTimeText.text = string.Format("TIME:" + finishedTime);
            scoreText.text = string.Format("SCORE:" + scoreToString);
        } 

        if (currentLevel == 0)
        {
            objectOne.SetActive(false);
            whichAnt = 1;
            ChangeText("HEY MAX, I GOT AN ASSIGNMENT FOR YOU", whichAnt);
            lineNumber++;
        }
        if (currentLevel == 2)
        {
            objectOne.SetActive(false);
            objectTwo.SetActive(false);
            objectThree.SetActive(false);
            whichAnt = 1;
            ChangeText("MY BOI, GOOD JOB!", whichAnt);
            lineNumber++;
        }

        if (currentLevel == 4)
        {
            objectOne.SetActive(false);
            objectTwo.SetActive(false);
            objectThree.SetActive(false);
            whichAnt = 1;
            ChangeText("GOOD JOB, MAX.", whichAnt);
            lineNumber++;
        }
        if (currentLevel == 6)
        {
            objectOne.SetActive(false);
            objectTwo.SetActive(false);
            objectThree.SetActive(false);
            whichAnt = 1;
            ChangeText("GREAT JOB, MAX! BUT NOW I NEED YOU TO GO BACK TO THE DESERT.", whichAnt);
            lineNumber++;
        }
        if (currentLevel == 8)
        {
            objectOne.SetActive(false);
            objectTwo.SetActive(false);
            objectThree.SetActive(false);
            whichAnt = 2;
            ChangeText("THANK YOU, MAX, FOR MY FLOWERS.", whichAnt);
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
                        textToMain = "WHAT'S UP MY BOI?";
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
                        textToMain = "AND YEAH, SPACE IS TO PICK UP ITEMS. GOOD LUCK!";
                        whichAnt = 1;
                        break;
                    case 7:
                        textToMain = "OK BROTHER FROM ANOTHER MOTHER";
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
                        textToMain = "WE NEED MORE STUFF";
                        whichAnt = 1;
                        break;
                    case 2:
                        textToMain = "BRUH, NOT AGAIN. IT WAS DANGEROUS AS HELL";
                        whichAnt = 0;
                        break;
                    case 3:
                        textToMain = "YEAH, YEAH, YEAH, JUST DO IT";
                        whichAnt = 1;
                        break;
                    case 4:
                        textToMain = "NOW YOU HAVE TO BRING THREE THINGS";
                        whichAnt = 1;
                        break;
                    case 5:
                        textToMain = "THAT'S HOW THEY LOOK";
                        whichAnt = 1;
                        objectOne.SetActive(true);
                        objectTwo.SetActive(true);
                        objectThree.SetActive(true);
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
                        textToMain = "GOOD JOB, MAX.";
                        whichAnt = 1;
                        break;
                    case 2:
                        textToMain = "THAT WAS TOO EASY.";
                        whichAnt = 0;
                        break;
                    case 3:
                        textToMain = "OH? YOU WANT A CHALLENGE?";
                        whichAnt = 1;
                        break;
                    case 4:
                        textToMain = "SURE!";
                        whichAnt = 1;
                        break;
                    case 5:
                        textToMain = "OK, GO TO THE DESERT, AND BRING BACK A BONE";
                        whichAnt = 1;
                        objectOne.SetActive(true);
                        objectTwo.SetActive(true);
                        objectThree.SetActive(true);
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
                        textToMain = "BUT I JUST GOT HOME!";
                        whichAnt = 0;
                    break;
                    case 2:
                        textToMain = "TONIGHT IS THE QUEEN’S BIRTHDAY PARTY. I NEED YOU TO GO COLLECT HER FAVORITE DESERT ROSES.";
                        whichAnt = 1;
                    break;
                    case 3:
                        textToMain = "ANYTHING FOR MY QUEEN!";
                        whichAnt = 0;
                    break;
                    case 4:
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
                        textToMain = "YOU ARE A GOOD LIEUTENANT, I HAVE A MISSION FOR YOU. I WANT YOU TO GO AND PREPARE A NEW HOME FOR OUR COLONY.";
                        whichAnt = 2;
                        break;
                    case 3:
                        textToMain = "WHERE?";
                        whichAnt = 0;
                        break;
                    case 4:
                        textToMain = "ON THE MOON.";
                        whichAnt = 2;
                        break;
                    case 5:
                        textToMain = "WE’LL BE EVERYWHERE!";
                        whichAnt = 0;
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
        mainText.text = string.Format(text);
        antName.text = string.Format(" — " + antNames[ant]);
    }

}
