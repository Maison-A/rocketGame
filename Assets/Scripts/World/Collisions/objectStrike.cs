using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectStrike : MonoBehaviour
{
    // don't need start and update for this script
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly");
                break;
            case "Finish":
                Debug.Log("Finish");
                break;
            case "Fuel":
                Debug.Log("Fuel");
                break;
            default:
                Debug.Log("default");
                break;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
