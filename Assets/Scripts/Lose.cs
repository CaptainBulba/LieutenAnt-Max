using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    int levelToRestart;
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI antName;
    int lineNumber = 0;
    string textToMain;

    // Start is called before the first frame update
    void Start()
    {
        levelToRestart = PlayerPrefs.GetInt("levelTorestart");
        Debug.Log(levelToRestart);

        ChangeText("NOW WE GONNA STARVE BECAUSE OF YOU!");
        lineNumber++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (lineNumber)
            {
                case 1:
                    textToMain = "GO AGAIN!";
                    break;
                case 2:
                    SceneManager.LoadScene(levelToRestart);
                    break;
            }
            lineNumber++;
            ChangeText(textToMain);
        }
        
    }
    void ChangeText(string text)
    {
        mainText.text = string.Format(text);
        antName.text = string.Format(" — Bob");
    }


}


 