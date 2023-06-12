using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpin : MonoBehaviour
{
    [SerializeField] float spinSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpinXAxis();
    }

    void SpinXAxis()
    {
        float xValue = 0 * Time.deltaTime * spinSpeed;
        float zValue = 0 * Time.deltaTime * spinSpeed;
        float yValue = Time.deltaTime * spinSpeed;
        transform.Rotate(xValue, yValue, zValue);
    }
}
