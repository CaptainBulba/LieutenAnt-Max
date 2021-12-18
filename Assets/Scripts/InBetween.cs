using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InBetween : MonoBehaviour
{
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI antName;
    private int whichAnt; // 0 Max & 1 Bob
    private string[] antNames = { "MAX", "BOB" };
    private int lineNumber = 0;
    string textToMain;
    public GameObject blueberry;
    public GameObject leaf;
    public GameObject sand;
    int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel == 0)
        {
            blueberry.SetActive(false);
            whichAnt = 1;
            ChangeText("HEY MAX, I GOT AN ASSIGNMENT FOR YOU", whichAnt);
            lineNumber++;
        }
        if (currentLevel == 2)
        {
            blueberry.SetActive(false);
            leaf.SetActive(false);
            sand.SetActive(false);
            whichAnt = 1;
            ChangeText("MY BOI, GOOD JOB!", whichAnt);
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
                        blueberry.SetActive(true);
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
                        blueberry.SetActive(true);
                        leaf.SetActive(true);
                        sand.SetActive(true);
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
