using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // making move speed public to be serialized
    [SerializeField] float moveSpeed = 10f;
    Rigidbody rb = null;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        MovePlayer();
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
            //vector is direction and magnitude
            rb.AddRelativeForce(Vector3.up);
            Debug.Log("Space bar is pressed - THRUSTING");
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D is pressed - ROTATE RIGHT");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A is pressed - ROTATE LEFT");
        }
    }

    void MovePlayer()
    {
        // Time.deltaTime multiplies duration of frame tick to result in 1
        // ensuring that movement is consistent between machines with higher frame rates
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float yValue = 0 * Time.deltaTime;

        transform.Translate(xValue, yValue, zValue);
    }
}
