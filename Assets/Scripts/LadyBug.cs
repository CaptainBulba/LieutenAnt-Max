using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadyBug : MonoBehaviour
{
    public playerMovement character;
    bool isSlowDownOn;

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

   
