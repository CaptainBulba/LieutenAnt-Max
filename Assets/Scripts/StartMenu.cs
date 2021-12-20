using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    int currentLevel;
 
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (hit.collider != null)
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.name == "Play")
            {
                SceneManager.LoadScene(currentLevel + 1);
            }

            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.name == "Credits")
            {
                SceneManager.LoadScene(12);
            }

        }
    }
}
