using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{

    public int maxSpeed;
    public int minSpeed;
    private int speed;
    // Animator of player
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);

        if (speed >= 9) 
            animator.SetBool("Run Forward", true);
        else
            animator.SetBool("Walk Forward", true);
    }

    // Update is called once per frame
    void Update()
    {          
        this.transform.Translate(-1*Vector3.forward * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Red line")
            // The player takes damage
            GameObject.Find("Game Manager").GetComponent<Game_state>().takeDamage();
            // Destroys the enemy gameObject
            Destroy(this.gameObject);
    }
}
