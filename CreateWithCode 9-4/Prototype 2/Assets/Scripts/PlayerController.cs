using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement Variables
    public float horizontalInput;
    public float speed = 10.0f;
    //Boundary Variable
    public float xRange = 15.0f;

    //Projectile
    public GameObject projectilePrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //--Movement--//
        //Left and Right Input
        horizontalInput = Input.GetAxis("Horizontal");
        //Move left and right
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //--Movement Limiter--//
        //Prevent player from going passed -xRange
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        //Prevent player from going passed xRange
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        //--Shoot Projectile--//
        //If space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Fire projectilePrefab at PlayerPosition
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        //If key s is held
        /*
        if (Input.GetKey(KeyCode.S))
        {
            //Fire projectilePrefab at PlayerPosition
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        */
    }
}
