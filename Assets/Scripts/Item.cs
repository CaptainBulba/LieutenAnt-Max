using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Rigidbody2D rb;
    int spiderThrow;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        spiderThrow = PlayerPrefs.GetInt("spiderThrowItem");

        if(spiderThrow == 1)
        {
            if (collision.gameObject.tag == "Object" || collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Snail"
            || collision.gameObject.tag == "Ladybug")
            {

                rb.velocity = Vector3.zero;
                rb.bodyType = RigidbodyType2D.Kinematic;
                PlayerPrefs.SetInt("spiderThrowItem", 0);
            }
        }
        
    }
}
