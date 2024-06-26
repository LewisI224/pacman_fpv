using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pill : MonoBehaviour
{
    public AudioSource sound;
    public float speed = 1.0f;

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
        if(collider.gameObject.tag == "Player")
        {
            if (!sound.isPlaying)
            {
                sound.Play();
            }
            
            game_manager.score += 10;
            game_manager.pillsLeft -= 1;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;

        
    }
}
