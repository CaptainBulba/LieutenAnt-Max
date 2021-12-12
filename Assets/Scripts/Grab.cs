using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;
    float originalSpeed;

    // Update is called once per frame

    void Start()
    {

       originalSpeed = gameObject.GetComponent<playerMovement>().movementSpeed;
    }

    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, transform.localScale, rayDist);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Item")
        {
            if (Input.GetKey(KeyCode.G))
            {
                Debug.Log(gameObject.GetComponent<playerMovement>().spriteRenderer.sprite.name);
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                gameObject.GetComponent<playerMovement>().movementSpeed = 1f;
            }
            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                gameObject.GetComponent<playerMovement>().movementSpeed = originalSpeed;
            }
        }
      
    }
}
