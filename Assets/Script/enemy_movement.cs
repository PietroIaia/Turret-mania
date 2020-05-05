using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{

    public int maxSpeed = 4;
    public int minSpeed = 1;
    private int speed;
    // Animator of player
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (speed >= 9) 
            animator.SetBool("Run Forward", true);
        else
            animator.SetBool("Walk Forward", true);
        
            
        this.transform.Translate(-1*Vector3.forward * speed * Time.deltaTime, Space.World);

    }
}
