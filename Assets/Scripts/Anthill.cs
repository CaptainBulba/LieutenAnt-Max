using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Anthill : MonoBehaviour
{
    int currentLevel;
    int itemsToFinish;
    int itemsBrought = 0;
    public Sprite[] Anthillprites;
    public SpriteRenderer spriteRenderer;
    int spriteNumber = 0;
    public Timer time;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        if(currentLevel == 1)
        {
            itemsToFinish = 1;
        }
        else
        {
            itemsToFinish = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Item")
        {
            StartCoroutine(ItemPlaced(col.gameObject));
        }
    }
    private IEnumerator ItemPlaced(GameObject item)
    {
        
        yield return new WaitForSeconds(1);
        itemsBrought++;
        item.SetActive(false);
        spriteNumber += 1;
        spriteRenderer.sprite = Anthillprites[spriteNumber];

        
        yield return new WaitForSeconds(1);

        if(itemsBrought == itemsToFinish)
        {
            Debug.Log(time.timeRemaining);
            float finishedTime = time.startTime - time.timeRemaining;
            PlayerPrefs.SetFloat("timeRemaining", time.timeRemaining);
            PlayerPrefs.SetFloat("finishedTime", finishedTime);
            SceneManager.LoadScene(currentLevel + 1);
        }
    }
}
