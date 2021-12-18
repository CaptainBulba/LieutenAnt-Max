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
        Debug.Log("Item touched");
        if (collision.collider.tag == "Item")
        {
            
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;


        }
    }
}
