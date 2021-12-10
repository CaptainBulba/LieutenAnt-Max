using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    public Sprite[] charaterSprites;
    public SpriteRenderer spriteRenderer;
    public float bounceTime;
    public float bounce;
    bool isBouncing = false;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 UserInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(!isBouncing)
        {
            transform.Translate(UserInput * movementSpeed * Time.deltaTime);
            ChangeSprite(UserInput.x, UserInput.y);
        }
       
    }
   
    void OnCollisionEnter2D(Collision2D collision)
    {   
            if (collision.gameObject.name == "Snail")
            {
                isBouncing = true;
                rb.AddForce(collision.contacts[0].normal * bounce, ForceMode2D.Impulse);
                StartCoroutine(BounceCoroutine());
        }     
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
        spriteRenderer.sprite = charaterSprites[spriteNumber];
    }
}
