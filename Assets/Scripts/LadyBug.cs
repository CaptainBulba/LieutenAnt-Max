using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadyBug : MonoBehaviour
{
    public playerMovement character;
    bool isSlowDownOn;
    public float movementSpeed;
    public float MinCords;
    public float MaxCords;
    int direction = 0;
    public bool transformY = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        float dimensionToTransform;
        if (transformY == false)
        {
            dimensionToTransform = transform.position.x;
        }
        else
        {
            dimensionToTransform = transform.position.y;
        }

        switch (direction)
        {
            case 0:
                if (dimensionToTransform >= MinCords)
                {
                    if (!transformY)
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector2(-movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
                    }
                    else
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -movementSpeed);
                    }
                }
                else
                {
                    direction = 1;
                }
                break;

            case 1:
                if (dimensionToTransform <= MaxCords)
                {
                    if (!transformY)
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
                    }
                    else
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, movementSpeed);
                    }
                }
                else
                {
                    direction = 0;
                }
                break;
        }
    }
private void OnTriggerEnter2D()
    {
        if (!isSlowDownOn)
        {
            StartCoroutine(ExampleCoroutine()); 
        }
    }
    IEnumerator ExampleCoroutine()
    {
        float normalSpeed = character.movementSpeed;
        character.movementSpeed = character.movementSpeed - 9;
        isSlowDownOn = true;

        yield return new WaitForSeconds(5);

        character.movementSpeed = normalSpeed;
        isSlowDownOn = false;

    }
}

   
