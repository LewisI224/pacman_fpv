using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_sprint : MonoBehaviour
{

    private player_movement playerMovement;
    public float sprintSpeed = 10f;
    public float moveSpeed = 5f;

    private player_move_sounds playerFootsteps;
    private float volume = 0.6f;
    private float stepDistMove = 0.4f;
    private float stepDistSprint = 0.25f;


    void Awake()
    {
        playerMovement = GetComponent<player_movement>();
        playerFootsteps = GetComponentInChildren<player_move_sounds>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerFootsteps.volume = volume;
        playerFootsteps.stepDist = stepDistMove;
        playerFootsteps.footstepClip = playerFootsteps.footstepClips[0];
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

            playerFootsteps.stepDist = stepDistSprint;
            playerFootsteps.volume = volume;
            playerFootsteps.footstepClip = playerFootsteps.footstepClips[1];
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerMovement.speed = moveSpeed;

            playerFootsteps.stepDist = stepDistMove;
            playerFootsteps.volume = volume;
            playerFootsteps.footstepClip = playerFootsteps.footstepClips[0];
        }
    }
}
