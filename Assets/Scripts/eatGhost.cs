using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatGhost : MonoBehaviour
{
    public AudioSource sound;
    public static bool powerUp;

    public float amplitude = 0.5f;
    public float frequency = 1f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    
    void Start()
    {
        posOffset = transform.position;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (!sound.isPlaying)
            {
                sound.Play();
            }

            game_manager.score += 100;
            game_manager.pillsLeft -= 1;
            game_manager.gameState = game_manager.GameState.EATGHOSTS;
            game_manager.eatGhostTime = 15f;
            Destroy(gameObject);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
