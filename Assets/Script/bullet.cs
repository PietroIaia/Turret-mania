using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public int bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        // Gets the direction to shoot
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Shoots the bullet
        this.gameObject.GetComponent<Rigidbody>().AddForce(ray.direction * bulletSpeed);
    }

    private void OnCollisionEnter(Collision col)
    {
        // If collides with Enemy, destroys enemy
        if (col.gameObject.name == "Boximon Fiery(Clone)")
        {
            Destroy(col.gameObject);
        }
        // Destroys the shell when it collides with anything
        Destroy(this.gameObject);
    }
}
