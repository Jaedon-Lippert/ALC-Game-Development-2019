using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneIdle : MonoBehaviour
{
    private float xamount;
    private bool invisible;
    public GameObject Player;
    private PlayerControllerX PlayerScript;
    // Start is called before the first frame update
    void Start()
    {
        PlayerScript = Player.GetComponent<PlayerControllerX>();
    }

    // Update is called once per frame
    void Update()
    {
        xamount += 0.05f;
        transform.Translate(Vector3.up * (Mathf.Sin(xamount) / 100), Space.World);

        //If on cool down, make bone disappear
        if (PlayerScript.GetCoolDown() && !invisible)
        {
            GetComponent<MeshRenderer>().enabled = false;
            invisible = true;
        }
        else if(!PlayerScript.GetCoolDown() && invisible)
        {
            GetComponent<MeshRenderer>().enabled = true;
            invisible = false;
        }
    }
}
