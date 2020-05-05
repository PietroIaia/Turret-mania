using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;              // This was manually added 

public class Game_state : MonoBehaviour
{
    // Player's health
    private int health = 3;
    // Player's score
    private int score = 0;

    public void takeDamage()
    {
        health -= 1;
        // If health drops to zero or below, it restarts the game 
        if (health <= 0)
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        }
    }
}
