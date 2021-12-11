using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
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
        /*   Vector2 UserInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
           if(!isBouncing)
           {
               transform.Translate(UserInput * movementSpeed * Time.deltaTime);
              rb.MovePosition(rb.position + movementSpeed * Time.deltaTime);
               
           } */

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (change != Vector3.zero)
        {
            Move();
            ChangeSprite(change.x, change.y);
        }

        if (Input.GetKey(KeyCode.E))
        {
            if(pullObjectName == "item")
            {
                GameObject.Find("item").GetComponent<Rigidbody2D>().position = new Vector3(rb.position.x - 0.1f, rb.position.y - 0.1f);
                movementSpeed = 1f;
            }
                
        }
        else
        {
          //  movementSpeed = originalMovementSpeed;
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
            Debug.Log("Yeah");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        pullObjectName = "";
    }
        private IEnumerator BounceCoroutine()
    {
        yield return new WaitForSeconds(bounceTime);
        rb.velocity = Vector2.zero;
        isBouncing = false;
    }
void ChangeSprite(float x, float y)
    {
        int spriteNumber = 1;
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
        spriteRenderer.sprite = charaterSprites[spriteNumber];
    }
}
