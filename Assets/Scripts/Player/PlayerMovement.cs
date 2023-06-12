using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // making move speed public to be serialized
    [SerializeField] float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        movePlayer();
    }

    void ProcessInput()
    {

    }

    void movePlayer()
    {
        // Time.deltaTime multiplies duration of frame tick to result in 1
        // ensuring that movement is consistent between machines with higher frame rates
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float yValue = 0 * Time.deltaTime;

        transform.Translate(xValue, yValue, zValue);
    }
}
