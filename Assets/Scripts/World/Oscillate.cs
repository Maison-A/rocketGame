using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Oscillate : MonoBehaviour
{
    Vector3 StartingPos;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;

    void Start()
    {
        StartingPos = transform.position;
        
    }

    void Update()
    {
        // Epsilon is the smallest float - we must use that instead
        // since 0f can be a different number
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period; // continues to grow over time
        const float tau = Mathf.PI*2; // const val of 6.283..
        
        float rawSinWave = Mathf.Sin(cycles * tau);// should give us a value of -1 to 1
        movementFactor = (rawSinWave + 1f)/ 2f; // recalculated to go from 0 -> 1
        Vector3 offset = movementVector * movementFactor;
        transform.position = StartingPos + offset;
    }
}
