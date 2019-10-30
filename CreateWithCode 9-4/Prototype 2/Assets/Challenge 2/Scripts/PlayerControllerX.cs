using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float coolDownTimer = 0.5f;
    public bool onCoolDown = false;

    public bool GetCoolDown() { return onCoolDown; }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && !onCoolDown)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            onCoolDown = true;
            Invoke("ResetCoolDown", coolDownTimer);
        }
    }

    void ResetCoolDown()
    {
        onCoolDown = false;
    }
}