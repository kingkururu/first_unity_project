using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private PolygonCollider2D pc;
    private bool carryingObject = false;
    private GameObject player;
    public GameObject matchingLock; 

    // Start is called before the first frame update
    void Start()
    {
        pc = gameObject.AddComponent<PolygonCollider2D>();
        pc.isTrigger = true;
        //bc.size = new Vector2(bc.size.x, bc.size.y);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            PickUpKey();
        }

        if (other.gameObject == matchingLock)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (gameObject.transform.parent == null)
        {
            carryingObject = false;
        }
    }

    void PickUpKey()
    {
        if (!carryingObject)
        {
            Debug.Log("pick up");
            carryingObject = true;
            gameObject.transform.parent = player.transform;
        }
    }
}
