using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float baseSpeed;

    private float TrueSpeed {
        get {
            if (baseSpeed / enemyRb.mass > 6.5f) return 6.5f;
            else return baseSpeed / enemyRb.mass;
        }
    }
    private Rigidbody enemyRb;
    private GameObject player;
    public int existIndex;

    private SpawnManager gameSpawnManager;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gameSpawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = new Vector3(player.transform.position.x - transform.position.x, 0.0f, player.transform.position.z - transform.position.z).normalized;
        enemyRb.AddForce(lookDirection * TrueSpeed);

        if(transform.position.y < -10.0f)
        {
            gameSpawnManager.enemyCount--;
            Destroy(gameObject);
        }
    }
}
