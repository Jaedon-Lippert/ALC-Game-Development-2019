using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpPower;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool isBlocked = false;
    public bool gameOver = false;
    private Animator playerAnim;
    private AudioSource playerAudio;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                //playerRb.AddForce(Vector3.up * jumpPower);
                dirtParticle.Stop();
                playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                isOnGround = false;
                playerAnim.SetTrigger("Jump_trig");
                playerAudio.PlayOneShot(jumpSound, 1.0f);
            }

            if (!isBlocked && transform.position.x < 1)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * 1);
                Debug.Log("Moving Forward");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        //If player hits an object
        else if(collision.gameObject.CompareTag("Obstacle")){
            explosionParticle.Play();
            Debug.Log("Game Over");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isBlocked = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isBlocked = false;
    }
}
