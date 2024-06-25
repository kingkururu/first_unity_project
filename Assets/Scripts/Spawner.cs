using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject spawnFromHere;
    public bool randomRotation = true;
    public bool spawnForever = true;
    public float spawnRate = 1f;
    public float numObjectsToSpawn = Mathf.Infinity;
    public bool spawnFromTrigger = false;
    
   
    // Start is called before the first frame update
    void Start()
    {
        if (!spawnFromTrigger)
        {
            InvokeRepeating("Spawn", 1 / spawnRate, 1 / spawnRate);
        }
        
        if (spawnForever)
        {
            numObjectsToSpawn = Mathf.Infinity;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && spawnFromTrigger)
        {
            Spawn();
        }
    }

    
    // Spawn is called by InvokeRepeating once every spawnRate amount of time
    void Spawn()
    {
        if (numObjectsToSpawn > 0 || spawnForever)
        {
            if (randomRotation)
            {
                Instantiate(prefabToSpawn, spawnFromHere.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
            }
            else
            {
                Instantiate(prefabToSpawn, spawnFromHere.transform.position, transform.rotation);
            }

            if (!spawnForever)
            {
                numObjectsToSpawn--;
            } 
        }
        
    }
}
