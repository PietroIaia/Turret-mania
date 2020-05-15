using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Cannon : MonoBehaviour {

    public GameObject bullet;
    public GameObject shootPoint;
    public int bulletSpeed;
    public float waitingTime;
    private float LastShotTimer = 0;

    private void Update()
    {
        // The ray you cast with the mouse
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Change rotation to look at the direction of the ray
        var rotation = Quaternion.LookRotation(ray.direction, Vector3.up);
        this.gameObject.transform.rotation = rotation;
    }

    private void LateUpdate()
    {
        LastShotTimer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && LastShotTimer > waitingTime)
        {
            var bullet_inst = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
            // Transform.forward gets the forward direction relative to Cannon rotation.
            bullet_inst.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);

            // When the bullet is fired, we stop the current iteration of the particle and start a new one
            gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<ParticleSystem>().Stop();
            gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();

            LastShotTimer = 0;
        }
    }
}