using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Array
    public GameObject[] animalPrefabs = new GameObject[3];

    //Location
    public float xPos;
    public float xRange = 15;
    public float zLocation = 20;

    //Randomizer
    System.Random rSeed;

    //Timer
    private float startDelay = 2f;
    private float spawnInterval= 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Creates new randomizer seed to prevent duplication of sequences
        rSeed = new System.Random();

        //Timed Intervals
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomAnimal();
        }
        */
    }

    void SpawnRandomAnimal()
    {
        //Selects a random animal from array
        int animalIndex = rSeed.Next(0, animalPrefabs.Length);
        //Random position within xRange
        xPos = ((float)rSeed.NextDouble() * 2 * xRange) - xRange;

        //Instantiates animal prefab
        Instantiate(animalPrefabs[animalIndex], new Vector3(xPos, 0, zLocation), animalPrefabs[animalIndex].transform.rotation);
    }
}
