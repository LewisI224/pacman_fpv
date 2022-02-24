using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_movement : MonoBehaviour
{
    private CharacterController characterController;

    private Vector3 direction;
    public float gravity = 20f;
    private float verticalVelocity;
    public float speed = 5f;
    public GameObject player;

    public AudioSource dieSound;
    private Vector3 startPos;

    void Awake() {
        characterController = GetComponent<CharacterController>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        Movement();
    }

    void Movement() {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        direction = transform.TransformDirection(direction);

        direction *= speed * Time.deltaTime;
        applyGravity();
        characterController.Move(direction);
    }

    void applyGravity()
    {
        verticalVelocity -= gravity;
        direction.y = verticalVelocity;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Ghost") && game_manager.gameState == game_manager.GameState.NORMAL)
        {
            game_manager.lives -= 1;
            
            if (game_manager.lives == 0)
            {
                GetComponent<player_movement>().enabled = false;
                FindObjectOfType<game_manager>().GameOver();
            }
            else
            {
                player.SetActive(false);
                transform.position = startPos;
                player.SetActive(true);
            }
            dieSound = GetComponent<AudioSource>();
            dieSound.Play();


        }
    }

    
}
