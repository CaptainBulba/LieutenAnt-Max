using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "Item")
        {
         //   Debug.Log("Item touched");
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;


        }
    }
}
