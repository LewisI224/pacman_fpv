using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private CharacterController characterController;

    private Vector3 direction;

    public float speed = 5f;
    
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        direction = transform.TransformDirection(direction);

        direction *= speed * Time.deltaTime;

        characterController.Move(direction);
    }
}
