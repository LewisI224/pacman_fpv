using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public void Restart()
    {
        game_manager.gameEnded = false;
        game_manager.gameWon = false;
        game_manager.pillsLeft = 1;
        game_manager.score = 0;
        SceneManager.LoadScene("SampleScene");
    }
}
