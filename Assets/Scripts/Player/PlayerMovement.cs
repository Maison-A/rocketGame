using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // making move speed public to be serialized
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotateThrust = 100f;
    Rigidbody rb = null;
    AudioSource asSource = null;
    
    // Start is called before the first frame update
    void Start()
    {
        // get reference to component rigidbody and set to rb
        rb = GetComponent<Rigidbody>();
        // get audio source
        asSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        // GetKey will return true while input is held
        // don't use string reference overload due to nature of naming
        if (Input.GetKey(KeyCode.Space))
        {
            if (!asSource.isPlaying)
            {
                asSource.Play();
            }
            //vector is direction and magnitude
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            Debug.Log("Space bar is pressed - THRUSTING");
        }
        else
        {
            asSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotate(rotateThrust);
            Debug.Log("A is pressed - ROTATE LEFT");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            
            ApplyRotate(-rotateThrust); // add a negative
            Debug.Log("D is pressed - ROTATE RIGHT");
        }
                
    }

    void ApplyRotate(float rotationThisFrame)
    {
        
        rb.freezeRotation = true; // freeze engine physics rotation while inputing manual rottion
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // continue engine physics
    }
}
