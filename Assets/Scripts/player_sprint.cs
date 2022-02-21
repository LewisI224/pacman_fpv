using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_sprint : MonoBehaviour
{

    private player_movement playerMovement;
    public float sprintSpeed = 10f;
    public float moveSpeed = 5f;


    private float stepDistMove = 0.4f;
    private float stepDistSprint = 0.25f;


    void Awake()
    {
        playerMovement = GetComponent<player_movement>();
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
    }

    void Sprint()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerMovement.speed = sprintSpeed;


        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerMovement.speed = moveSpeed;
        }
    }
}
