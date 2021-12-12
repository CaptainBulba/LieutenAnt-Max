using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadyBug : MonoBehaviour
{
    public PlayerMovement character;
    bool isSlowDownOn;
    public float slowDownSpeed;
    public float slowDownTime;

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
        character.movementSpeed = character.movementSpeed - slowDownSpeed;
        isSlowDownOn = true;

        yield return new WaitForSeconds(slowDownTime);

        character.movementSpeed = normalSpeed;
        isSlowDownOn = false;

    }
}

   
