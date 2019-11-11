using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpPower;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool isBlocked = false;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            //playerRb.AddForce(Vector3.up * jumpPower);
            playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isOnGround = false;
        }

        if (!isBlocked && transform.position.x < 1)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 1);
            Debug.Log("Moving Forward");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if(collision.gameObject.CompareTag("Obstacle")){
            Debug.Log("Game Over");
            gameOver = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isBlocked = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isBlocked = false;
    }
}
