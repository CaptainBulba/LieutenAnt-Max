using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public Sprite[] charaterSprites;
    public SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        Move();
    }
   
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
        ChangeSprite(moveDirection.x, moveDirection.y);
    }


    void ChangeSprite(float x, float y)
    {
        int spriteNumber = 1;
        if (y == -1) // down
        {
            spriteNumber = 0;
        } else if (y == 1) // up
        {
            spriteNumber = 1;
        }

        if (x == -1) // left
        {
            spriteNumber = 2;
        } 
        else if (x == 1) // right
        {
            spriteNumber = 3;
        }
      //  Debug.Log(spriteNumber);
        spriteRenderer.sprite = charaterSprites[spriteNumber];
    }
}
