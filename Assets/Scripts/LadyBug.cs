using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadyBug : MonoBehaviour
{
    public PlayerMovement character;
    public bool isSlowDownOn = false;
    public float slowDownSpeed;
    public float slowDownTime;
    float normalSpeed;

    void Start()
    {
        normalSpeed = character.movementSpeed;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && !isSlowDownOn)
        {
            StartCoroutine(slowDownTimer());
        }
    }
    IEnumerator slowDownTimer()
    {
        
        character.movementSpeed = character.movementSpeed - slowDownSpeed;
        isSlowDownOn = true;
        yield return new WaitForSeconds(slowDownTime);

        character.movementSpeed = normalSpeed;
        isSlowDownOn = false;
    }
}

   
