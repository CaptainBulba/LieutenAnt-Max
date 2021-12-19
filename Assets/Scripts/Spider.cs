using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public Grab grab;
    public float freezePlayerTime;
    float randomNumberX;
    float randomNumberY;
    public float timeToSpawn;
    public float spiderTimeActive;
    bool isSpawned;
    float timer = 0f;
    public Sprite[] trailSprites;
    public SpriteRenderer spriteRenderer;
    GameObject spider;


    // Start is called before the first frame update
    void Start()
    {
        spider = gameObject;
        spider.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToSpawn && !isSpawned)
        {
            StartCoroutine(SpawnSpider());
        }
    }

    IEnumerator SpawnSpider()
    {
        spider.GetComponent<Renderer>().enabled = true;
        spriteRenderer.sprite = trailSprites[0];

        yield return new WaitForSeconds(2);
        spriteRenderer.sprite = trailSprites[1];
        isSpawned = true;

        yield return new WaitForSeconds(spiderTimeActive);
        spider.GetComponent<Renderer>().enabled = false;
        isSpawned = false;
        timer = 0f;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(gameObject.name + " Collided" + col.gameObject.name);

        if (grab != null && grab.isPicked && isSpawned)
        {
            grab.itemHolding.GetComponent<Rigidbody2D>().simulated = true;
            grab.itemHolding.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            grab.itemHolding.transform.parent = null;
            grab.itemHolding.transform.position = grab.grabDetect.position;

            float whichSide = Random.Range(0, 2);

            switch (whichSide)
            {
                case 0:
                    randomNumberX = Random.Range(2.0f, 7.0f);
                    randomNumberY = Random.Range(2.0f, 7.0f);
                    break;
                case 1:
                    randomNumberX = Random.Range(-2.0f, -7.0f);
                    randomNumberY = Random.Range(-2.0f, -7.0f);
                    break;
            }
            grab.itemHolding.GetComponent<Rigidbody2D>().velocity = new Vector3(randomNumberX, randomNumberY, 0);
            PlayerPrefs.SetInt("spiderThrowItem", 1);
            grab.isPicked = false;

            StartCoroutine(FreezePlayer());
        }
    }
    IEnumerator FreezePlayer()
    {
        grab.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        grab.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        yield return new WaitForSeconds(freezePlayerTime);

        grab.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        grab.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        grab.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

    }
}