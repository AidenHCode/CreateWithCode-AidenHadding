using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool GameOver = false;
    public bool isOnGround = true;
    public float gravityModifier;
    public float jumpForce;
    public ParticleSystem explosionParticle;
    private Rigidbody playerRb;
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !GameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.CompareTag("Ground")) 
        { 
            isOnGround = true; 
        }
            else if (collision.gameObject.CompareTag("Obstacle"))
         { 
            GameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
         }
    }
}

