using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDrop : MonoBehaviour
{
    MeshRenderer render;
    Rigidbody rigidBody;
    [SerializeField] float delay = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<MeshRenderer>();
        rigidBody = GetComponent<Rigidbody>();

        render.enabled = false;
        rigidBody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= delay)
        {
            render.enabled = true;
            rigidBody.useGravity = true;
        }
    }
}
