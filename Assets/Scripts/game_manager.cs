using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class game_manager : MonoBehaviour
{
    public GameObject gameOverScreen;

    public GameObject winScreen;
    public static bool gameWon = false;

    public GameObject scoreText;
    public static int score;
    public GameObject pillsText;
    public static int pillsLeft = 1;

    private AudioSource dieSound;
    public static bool gameEnded = false;

    public void GameOver()
    {
        if (gameEnded == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            gameEnded = true;  
            dieSound = GetComponent<AudioSource>();
            dieSound.Play();
            gameOverScreen.SetActive(true);
        }
        
    }

    void Update()
    {
        
        scoreText.GetComponent<Text>().text = "Score: " + score;
        pillsText.GetComponent<Text>().text = "Pills Left: " + pillsLeft;
        
        if (pillsLeft == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            gameWon = true;
            winScreen.SetActive(true);
        }
    }

}