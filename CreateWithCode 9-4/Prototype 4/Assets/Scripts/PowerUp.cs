using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int existIndex;


    private SpawnManager gameSpawnManager;

    // Start is called before the first frame update
    void Start()
    {
        gameSpawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gameSpawnManager.powerUpCount--;
    }
}
