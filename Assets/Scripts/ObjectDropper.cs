using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDropper : MonoBehaviour
{
    public GameObject[] objectsToDrop;

    void Start()
    {
        for (int i = 0; i < objectsToDrop.Length; i++)
        {
            objectsToDrop[i].GetComponent<Rigidbody2D>().simulated = false;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i < objectsToDrop.Length; i++)
        {
            objectsToDrop[i].GetComponent<Rigidbody2D>().simulated = true;
            objectsToDrop[i].gameObject.transform.parent = null;
        }
    }
}
