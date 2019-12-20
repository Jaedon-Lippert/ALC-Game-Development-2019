﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12.0f;
    private float maxSpeed = 16.0f;
    private float maxTorque = 10.0f;
    private Vector3 basePos = new Vector3(0.0f, 0.0f, 0.0f);
    private float xRange = 4.0f;
    private float ySpawnPos = -6.0f;
    private GameManager gameManager;
    public ParticleSystem particle;

    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        targetRb.transform.position = RandomSpawnPos();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameObject.name.Contains("Good_02")) pointValue = Random.Range(2, pointValue + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!CompareTag("Bad") && gameManager.isGameActive)
        {
            gameManager.UpdateScore(pointValue);
            Instantiate(particle, transform.position, particle.transform.rotation);
            Destroy(gameObject);
        }
        else if (gameManager.isGameActive)
        {
            Instantiate(particle, transform.position, particle.transform.rotation);
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(basePos.x + Random.Range(-xRange, xRange), basePos.y + ySpawnPos);
    }
}
