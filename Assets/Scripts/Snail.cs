using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{

    public float changeSpriteTime;
    public Sprite[] trailSprites;
    public SpriteRenderer spriteRenderer;
    int spriteNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeSprite());
    }

    void Update()
    {
        
    }

    IEnumerator ChangeSprite()
        {
            for (; ;)
            {
                yield return new WaitForSeconds(changeSpriteTime);

                if (spriteNumber == 4)
                {
                    spriteNumber = 0;
                }
                else
                {
                    spriteNumber++;
                }
                spriteRenderer.sprite = trailSprites[spriteNumber];
            }
        }

    }