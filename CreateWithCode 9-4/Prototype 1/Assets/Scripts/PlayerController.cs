using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public Variables
    private float speed = 11.5f;
    private float turnSpeed = 90f;
    private float horizontalInput;
    private float verticalInput;

    //public float boostInput;
    //public float boostSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Button Presses
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //BOOST
        //boostInput = Input.GetAxis("Fire1");

        //Move Forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput/* * (1 + (boostInput * boostSpeed))*/);

        //Rotate
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        //Move Right
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput)
    }
}
