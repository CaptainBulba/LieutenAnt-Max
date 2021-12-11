using UnityEngine;
using System.Collections;

public class SnailTwo : MonoBehaviour
{

    public float pushForce = 10;
    public Rigidbody2D rb;
    public Rigidbody2D rb2;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("touched");
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 1f * 10f, ForceMode2D.Impulse);
    }



}