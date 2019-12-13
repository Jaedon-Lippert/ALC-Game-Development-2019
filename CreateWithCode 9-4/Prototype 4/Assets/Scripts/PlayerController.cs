using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forewardInput = Input.GetAxis("Vertical");
        //playerRb.AddForce(Vector3.forward * speed * forewardInput);
        playerRb.AddForce(focalPoint.transform.forward * speed * forewardInput);
    }
}
