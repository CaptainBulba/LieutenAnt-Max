using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
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
        Debug.Log("Update");
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
                // Moving Left
                Debug.Log(transform.position.x + " transform");
                Debug.Log(MinCords);
                if (dimensionToTransform > MinCords)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
                }
                else
                {
                    direction = 1;
                }
                break;
            case 1:
                //Moving Right
                if (dimensionToTransform < MaxCords)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
                }
                else
                {
                    direction = 0;
                }
                break;
        }
    }
}