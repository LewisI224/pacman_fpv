using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1f;
        game_manager.gameEnded = false;
        game_manager.gameWon = false;
        game_manager.pillsLeft = game_manager.totalPills;
        game_manager.score = 0;
        SceneManager.LoadScene("SampleScene");
    }
}
