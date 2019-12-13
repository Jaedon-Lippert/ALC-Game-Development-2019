using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    public float initAccel = 0.5f;
    public float accelRate;
    public float maxAccel;
    private float acceleration;
    // Start is called before the first frame update
    void Start()
    {
        acceleration = initAccel;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * acceleration * Time.deltaTime);
        if ( (horizontalInput > 0.0f || horizontalInput < 0.0f) && acceleration < maxAccel)
        {
            acceleration *= 1 + Time.deltaTime * accelRate;
        }
        else if (!(horizontalInput > 0.0f) && !(horizontalInput < 0.0f)) acceleration = initAccel;
    }
}
