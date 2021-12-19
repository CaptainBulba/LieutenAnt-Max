using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public Grab grab;
    public float freezePlayerTime;
    float randomNumberX;
    float randomNumberY;
    public float locationX;
    public float locationY;
    public float timeToSpawn;
    bool isSpawned;
    float timer = 0f;
    public Sprite[] trailSprites;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToSpawn)
        {
            SpawnSpider();
        }
    }

    void SpawnSpider()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(grab != null && grab.isPicked)
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
            Debug.Log(whichSide + " RandomX:" + randomNumberX + " RandomY: " + randomNumberY);
            grab.itemHolding.GetComponent<Rigidbody2D>().velocity = new Vector3(randomNumberX, randomNumberY, 0);

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

