using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_enemy : MonoBehaviour
{
    public GameObject enemy;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    private float Xpos;
    private float Zpos;

    private void Start()
    {
        StartCoroutine(spawner());
    }

    IEnumerator spawner()
    {
        while(true)
        {
            Xpos = Random.Range(minX, maxX);
            Zpos = Random.Range(minZ, maxZ);
            // Instancia al enemigo, rotado 180 grados en el axis y.
            Instantiate(enemy, new Vector3(Xpos, -14.73519f, Zpos), Quaternion.Euler(new Vector3(0, 180, 0)));
            yield return new WaitForSeconds(1f); 
        }
    }
}
