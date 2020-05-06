using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Cannon : MonoBehaviour {

    public GameObject bullet;
    public GameObject shootPoint;
    private void Update()
    {
        // The ray you cast with the mouse
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Change rotation to look at the direction of the ray
        this.gameObject.transform.rotation = Quaternion.LookRotation(ray.direction, Vector3.up);
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
        }
    }
}