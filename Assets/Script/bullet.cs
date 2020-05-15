using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        // If collides with Enemy, destroys enemy
        if (col.gameObject.name == "Boximon Fiery(Clone)")
        {
            GameObject.Find("Game Manager").GetComponent<Game_state>().addScore();
            Destroy(col.gameObject);
        }
        // Destroys the shell when it collides with anything
        Destroy(this.gameObject);
    }
}
