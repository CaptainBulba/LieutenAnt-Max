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
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        switch (currentLevel)
        {
            case 1:
                itemsToFinish = 1;
                break;
            case 3:
                itemsToFinish = 4;
                break;
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
        if(spriteNumber != 3)
        {
            spriteRenderer.sprite = Anthillprites[spriteNumber];
        }
        
        yield return new WaitForSeconds(1);

        if(itemsBrought == itemsToFinish)
        {
            SceneManager.LoadScene(currentLevel + 1);
        }

    }
}
