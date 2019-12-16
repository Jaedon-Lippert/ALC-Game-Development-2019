using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int enemyCount = 0;
    public int powerUpCount = 0;

    private float spawnRange = 9;
    private int waveNumber = 0;

    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    //start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(3);

        RandomPositionFromCenter rPos = new RandomPositionFromCenter(-spawnRange, spawnRange);
        CreatePowerUp(rPos.xPos, rPos.zPos);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCount == 0)
        {
            RandomPositionFromCenter rPos = new RandomPositionFromCenter(-spawnRange, spawnRange);
            waveNumber++;
            SpawnEnemyWave(3 + waveNumber);
            CreatePowerUp(rPos.xPos, rPos.zPos);
        }
    }

    //Enemy
    private void CreateEnemy(float spawnPosX, float spawnPosZ, float size)
    {
        enemyCount++;

        Enemy newEnemy = Instantiate(enemyPrefab, new Vector3(spawnPosX,0,spawnPosZ), enemyPrefab.transform.rotation).GetComponent<Enemy>();
        newEnemy.transform.localScale = new Vector3(size, size, size);
        newEnemy.GetComponent<Rigidbody>().mass = size/1.5f;
    }

    //Enemy - Wave
    private void SpawnEnemyWave(int count)
    {
        for (int i = 0; i < count; i++)
        {
            RandomPositionFromCenter rPos = new RandomPositionFromCenter(-spawnRange, spawnRange);
            CreateEnemy(rPos.xPos, rPos.zPos, Random.Range(0.5f, 2.0f));
        }
    }

    //Power Ups
    private void CreatePowerUp(float spawnPosX, float spawnPosZ)
    {
        powerUpCount++;

        GameObject newObject = Instantiate(powerUpPrefab, new Vector3(spawnPosX, 0, spawnPosZ), powerUpPrefab.transform.rotation);
        PowerUp newPowerUp = newObject.GetComponent<PowerUp>();
    }



    public class RandomPositionFromCenter
    {
        public readonly float xPos;
        public readonly float yPos;
        public readonly float zPos;

        public Vector3 Position => new Vector3(xPos, yPos, zPos);

        public RandomPositionFromCenter(float min, float max)
        {
            xPos = Random.Range(min, max);
            yPos = Random.Range(min, max);
            zPos = Random.Range(min, max);
        }
    }
}