using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs = new GameObject[3];
    public int animalIndex;
    public int xPos;
    System.Random rSeed;
    // Start is called before the first frame update
    void Start()
    {
        rSeed = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        animalIndex = rSeed.Next(0, animalPrefabs.Length);
        xPos = rSeed.Next(-20,20);

        if (Input.GetKey(KeyCode.S))
        {
            Instantiate(animalPrefabs[animalIndex], new Vector3(xPos, 0, 20), animalPrefabs[animalIndex].transform.rotation);
        }
    }
}
