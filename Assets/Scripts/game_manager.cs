using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class game_manager : MonoBehaviour
{

    public GameObject gameOverScreen;
    public GameObject winScreen;
    public static bool gameWon = false;
    public static bool displayed = false;
   
    //start of game text
    public GameObject run;
    public GameObject eat;
    public GameObject survive;

    //power up text
    public GameObject powerup;
    public GameObject location;


    //gui text
    public GameObject livesText;
    public GameObject scoreText;
    public static int score;
    public GameObject pillsText;
    public static int totalPills;
    public static int pillsLeft;
    public static int lives;
    public GameObject timer;

    public GameObject powerup1;

    public AudioSource winSound;

    public static bool gameEnded = false;

    public float powerTimer;

    public static float eatGhostTime = 15f;
    public static GameState gameState;
    public enum GameState
    {
        NORMAL, EATGHOSTS, TIMEREND
    }

    void Start()
    {
        totalPills = GameObject.FindGameObjectsWithTag("Pill").Length;
        pillsLeft = 14;
        gameState = GameState.NORMAL;
        timer.GetComponent<Text>().text = "";
        StartCoroutine(text());
        powerTimer = 0f;
        lives = 3;



    }
    IEnumerator text()
    {
        run.SetActive(true);
        yield return new WaitForSeconds(1);
        run.SetActive(false);
        eat.SetActive(true);
        yield return new WaitForSeconds(1);
        eat.SetActive(false);
        survive.SetActive(true);
        yield return new WaitForSeconds(1);
        survive.SetActive(false);
    }

    IEnumerator poweruptext()
    {
        powerup.SetActive(true);
        location.SetActive(true);
        yield return new WaitForSeconds(2);
        powerup.SetActive(false);
        location.SetActive(false);
    }

    public void GameOver()
    {
        if (gameEnded == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            gameEnded = true;
            
            gameOverScreen.SetActive(true);
        }
        
    }


    public void win()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        gameWon = true;
        winSound = GetComponent<AudioSource>();
        winSound.Play();
        winScreen.SetActive(true);
    }

    void Update()
    {
        if (pillsLeft == totalPills/2)
        {
            powerup1.SetActive(true);
            StartCoroutine(poweruptext());

        }
        
        livesText.GetComponent<Text>().text = "Lives Left: " + lives;
        scoreText.GetComponent<Text>().text = "Score: " + score;
        pillsText.GetComponent<Text>().text = "Pills Left: " + pillsLeft;
        
        if (pillsLeft == 0)
        {
            win();

            
        }
        if (gameState == GameState.EATGHOSTS)
        {
            if (eatGhostTime <= 0f)
            {
                timer.GetComponent<Text>().text = "";
                gameState = GameState.TIMEREND;
                eatGhostTime = 15f;
            }
            else
            {
                timer.GetComponent<Text>().text = "Time to Eat:" + Math.Round(eatGhostTime, 0) + "s Left";
                eatGhostTime -= Time.deltaTime;
            }
        }

        
    }

}