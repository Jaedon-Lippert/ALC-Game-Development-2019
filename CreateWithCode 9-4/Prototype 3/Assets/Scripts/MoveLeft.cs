using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 25f;
    private PlayerController thePlayerController;
    // Start is called before the first frame update
    void Start()
    {
        thePlayerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!thePlayerController.gameOver)
            transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
