using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    [HideInInspector] public Transform grabDetect;
    public Transform grabFront;
    public Transform grabLeft;
    public Transform grabRight;
    public Transform grabBack;
    public Transform itemHolder;
    float originalSpeed;
    public float distance = 2f;
    [HideInInspector] public GameObject itemHolding;
    [HideInInspector] public bool isPicked;
    public float speedWithItem;
    

    void Start()
    { 
       originalSpeed = gameObject.GetComponent<PlayerMovement>().movementSpeed;
    }

    void Update()
    {
        switch(gameObject.GetComponent<PlayerMovement>().spriteNumber)
        {
            case 0:
                grabDetect = grabBack;
                break;
            case 1:
                grabDetect = grabFront;
                break;
            case 2:
                grabDetect = grabLeft;
                break;
            case 3:
                grabDetect = grabRight;
                break;
        }
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, transform.localScale, distance);
      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPicked)
            {
                itemHolding.GetComponent<Rigidbody2D>().simulated = true;
                itemHolding.transform.parent = null;
                itemHolding.transform.position = grabDetect.position;
                gameObject.GetComponent<PlayerMovement>().movementSpeed = originalSpeed;
                isPicked = false;
                return;
            }
            if (grabCheck.collider != null && grabCheck.collider.tag == "Item" && isPicked == false)
            {
                isPicked = true;
                itemHolding = grabCheck.collider.gameObject;
                grabCheck.collider.GetComponent<Rigidbody2D>().simulated = false;
                grabCheck.collider.gameObject.transform.parent = itemHolder;
                grabCheck.collider.gameObject.transform.position = itemHolder.position;
                gameObject.GetComponent<PlayerMovement>().movementSpeed = speedWithItem;
                return;
            }
            
        }
    }   
}

