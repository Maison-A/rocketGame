using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectStrike : MonoBehaviour
{
    // don't need start and update for this script
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            // GetComponent<type>()
            GetComponent<MeshRenderer>().material.color = Color.magenta;
            gameObject.tag = "Counted";
        }
        
    }

    private void OnCollisionExit(Collision other)
    {
        GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
