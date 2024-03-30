using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject planet;
    public float spawnRate;

    private float nextSpawn = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            Instantiate(planet, transform.position, planet.transform.rotation);
        }
    }
}
