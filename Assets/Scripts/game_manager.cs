using System.Collections;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    public GameObject gameOverScreen;
    private AudioSource dieSound;
    public AudioClip dieClip;
    bool gameEnded = false;
    public void GameOver()
    {
        if (gameEnded == false)
        {   
            gameEnded = true;  
            print("GAME OVER");
            dieSound = GetComponent<AudioSource>();
            dieSound.clip = dieClip;
            dieSound.Play();
            gameOverScreen.SetActive(true);
        }
        
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}