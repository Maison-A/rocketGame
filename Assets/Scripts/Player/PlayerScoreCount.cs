using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreCount : MonoBehaviour
{
    [SerializeField] int wallHitCount = 0;

    private void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.tag != "Counted")
        {
            wallHitCount++;
        }

        if(wallHitCount < 2)
        {
            Debug.Log("You've hit the wall " + wallHitCount + " time");

        }
        else
        {
            Debug.Log("You've hit the wall " + wallHitCount + " times");
        }

    }

   
}
