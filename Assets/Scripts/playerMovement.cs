using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    private Rigidbody2D rb;
    public Sprite[] charaterSprites;
    public SpriteRenderer spriteRenderer;
    public float bounceTime;
    public float bounce;
    bool isBouncing = false;
    bool isPulling = false;
    string pullObjectName;
    float originalMovementSpeed;

    bool isPushing = false;

    int spriteNumber = 1; // current sprite

    private Vector3 change;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalMovementSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if(!isBouncing)
        {
            if (change != Vector3.zero)
            {
                Move();
                ChangeSprite(change.x, change.y);
            }
        }
    }
    
    void Move()
    {
        rb.MovePosition(transform.position + change * movementSpeed * Time.fixedDeltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {   
        pullObjectName = collision.gameObject.name;

        if (collision.gameObject.name == "Snail")
        {
            isBouncing = true;
            rb.AddForce(collision.contacts[0].normal * bounce, ForceMode2D.Impulse);
            StartCoroutine(BounceCoroutine());
        }
        if (collision.gameObject.name == "item")
        {
            isPushing = true;
            
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        pullObjectName = "";
        if (collision.gameObject.name == "item")
        {
           // isPushing = false;
        }
    }
    private IEnumerator BounceCoroutine()
    {
        yield return new WaitForSeconds(bounceTime);
        rb.velocity = Vector3.zero;
        isBouncing = false;
    }
void ChangeSprite(float x, float y)
    {
        if (y == -1) // down
        {
            spriteNumber = 0;
        } 
        else if (y == 1) // up
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
        Destroy(GetComponent<BoxCollider2D>());
        gameObject.AddComponent<BoxCollider2D>();
        spriteRenderer.sprite = charaterSprites[spriteNumber];
    }
}
