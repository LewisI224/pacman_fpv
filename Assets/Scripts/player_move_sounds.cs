using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move_sounds : MonoBehaviour
{
    private AudioSource footstepSound;

    [SerializeField]
    public AudioClip[] footstepClips;

    public AudioClip footstepClip;

    private CharacterController character_Controller;

    [HideInInspector]
    public float volume;

    private float accumDist;

    [HideInInspector]
    public float stepDist;

    // Start is called before the first frame update
    void Awake()
    {
        footstepSound = GetComponent<AudioSource>();
        character_Controller = GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(character_Controller.velocity.sqrMagnitude > 0)
        {
            accumDist += Time.deltaTime;

            if (accumDist > stepDist)
            {
                if (!footstepSound.isPlaying) { 
                    footstepSound.volume = volume;
                    footstepSound.clip = footstepClip;
                    footstepSound.Play();

                    accumDist = 0f;
                }
            }

        }
        else
        {
            accumDist = 0f;
        }
            
    }

    
}
