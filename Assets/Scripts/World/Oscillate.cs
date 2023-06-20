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
    [SerializeField] [Range(0,1)] float movementFactor;

    void Start()
    {
        StartingPos = transform.position;
        
    }

    void Update()
    {
        Vector3 offset = movementVector * movementFactor;
        transform.position = StartingPos + offset;
    }
}
