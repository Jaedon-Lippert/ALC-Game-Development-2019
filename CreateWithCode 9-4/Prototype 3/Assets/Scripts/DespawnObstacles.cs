using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnObstacles : MonoBehaviour
{
    private float xEdge = -20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Despawn game object once x is less than xEdge
        if (gameObject.transform.position.x < xEdge) Destroy(gameObject);
    }
}
