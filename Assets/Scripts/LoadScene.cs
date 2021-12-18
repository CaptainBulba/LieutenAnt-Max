using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int levelToLoad;

    int currentLevel;
    bool buttonAlreadyPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }
    
    // Update is called once per frame
    void Update()
    {
       
        
        if (Input.GetKey(KeyCode.Return))
        {
            if (buttonAlreadyPressed == false)
            {
                buttonAlreadyPressed = true;

            }
            else
            {
                if (currentLevel == 0)
                {
                    Debug.Log("A key or mouse click has been detected");
                    LoadNextScene();
                }
            }
        } 
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject collisionGameObject = col.gameObject;
        if (collisionGameObject.name == "Player")
        {
            LoadNextScene() ;
        }
    }
    void LoadNextScene()
    {
        SceneManager.LoadScene(levelToLoad);
    }


}
