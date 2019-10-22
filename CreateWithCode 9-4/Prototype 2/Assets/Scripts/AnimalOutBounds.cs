using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalOutBounds : MonoBehaviour
{
    public float front_bound = 35.0f;
    public float back_bound = -15.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > front_bound)
        {
            Destroy(gameObject);
        }
        else if (back_bound > transform.position.z)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
