using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public Grab grab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(grab != null && grab.isPicked)
        {
            grab.itemHolding.GetComponent<Rigidbody2D>().simulated = true;
            grab.itemHolding.transform.parent = null;
            grab.itemHolding.transform.position = grab.grabDetect.position;
            grab.itemHolding.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 10.0f);
            grab.isPicked = false;
        }   
    }
}

