using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneIdle : MonoBehaviour
{
    float xamount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xamount += 0.1f;
        transform.Translate(Vector3.up * Mathf.Sin(xamount));
        
    }
}
