using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float movementSpeed;
    public float MinCords;
    public float MaxCords;
    int direction = 0;
    public bool transformY = false;

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
}
