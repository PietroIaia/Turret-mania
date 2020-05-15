using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;              // This was manually added 
using UnityEngine.UI;

public class Game_state : MonoBehaviour
{
    // Player's health
    private int health = 3;
    // Player's score
    private int score = 0;
    private Text ScoreText;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        ScoreText = GameObject.Find("Score Text").GetComponent<Text>();
    }

    public void takeDamage()
    {
        health -= 1;
        // If health drops to zero or below, it restarts the game 
        if (health <= 0)
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        }
    }

    public void addScore()
    {
        score += 100;
        ScoreText.text = "Score: " + score;
    }
}
