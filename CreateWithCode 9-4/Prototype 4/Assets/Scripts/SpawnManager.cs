using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Enemy[] enemyList;
    private int enemyCount;
    private int lastEnemy => enemyCount - 1;

    private PowerUp[] powerUpList;
    private int powerUpCount;
    private int lastPowerUp => powerUpCount - 1;

    private float spawnRange = 9;

    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    //start is called before the first frame update
    void Start()
    {
        RandomPositionFromCenter rPos = new RandomPositionFromCenter(-spawnRange, spawnRange);
        CreateEnemy(rPos.xPos, rPos.zPos);

        rPos = new RandomPositionFromCenter(-spawnRange, spawnRange);
        CreatePowerUp(rPos.xPos, rPos.zPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void CreateEnemy(float spawnPosX, float spawnPosZ)
    {
        Enemy[] temp = enemyList;

        enemyCount++;
        enemyList = new Enemy[enemyCount];

        for (int i = 0; i < enemyCount - 1; i++)
        {
            enemyList[i] = temp[i];
        }
        enemyList[lastEnemy] = Instantiate(enemyPrefab, new Vector3(spawnPosX,0,spawnPosZ), enemyPrefab.transform.rotation).GetComponent<Enemy>();
        enemyList[lastEnemy].existIndex = lastEnemy;
    }
    public void DestroyEnemy(int index)
    {
        //Adjust array

        //Destroy Enemy
        Destroy(enemyList[index].gameObject);
    }

    private void CreatePowerUp(float spawnPosX, float spawnPosZ)
    {
        PowerUp[] temp = powerUpList;

        powerUpCount++;
        powerUpList = new PowerUp[powerUpCount];

        for (int i = 0; i < powerUpCount - 1; i++)
        {
            powerUpList[i] = temp[i];
        }
        powerUpList[lastPowerUp] = Instantiate(powerUpPrefab, new Vector3(spawnPosX, 0, spawnPosZ), powerUpPrefab.transform.rotation).GetComponent<PowerUp>();
        powerUpList[lastPowerUp].existIndex = lastPowerUp;
    }
    public void DestroyPowerUp(int index)
    {
        //Adjust Array

        //Destroy PowerUp
        Destroy(powerUpList[index]);
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