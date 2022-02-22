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
    
    void Awake() {
        characterController = GetComponent<CharacterController>();
        
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
        if (collision.collider.gameObject.CompareTag("Ghost"))
        {
            GetComponent<player_movement>().enabled = false;
            FindObjectOfType<game_manager>().GameOver();
        }
    }

    
}
