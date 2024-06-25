using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public GameObject objectToMove;
    public GameObject[] targets;
    public float speed = 1f;
    private GameObject currentTarget;

    private bool fromTop = false;
    
    public bool moveWhenTriggered = false;
    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = targets[0];
        
        if (moveWhenTriggered)
        {
            canMove = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;

        for (int i = 0; i < targets.Length; i++)
        {
            if (objectToMove.transform.position == targets[i].transform.position)
            {
                if (i + 1 < targets.Length)
                {
                    currentTarget = targets[i + 1];
                }
                else
                {
                    currentTarget = targets[0];
                }
                
            }
        }
        
        if (canMove)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, currentTarget.transform.position, step);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        fromTop = true;
        
        if (moveWhenTriggered && other.gameObject.tag == "Player")
        {
            canMove = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (moveWhenTriggered && canMove && other.gameObject.tag == "Player")
        {
            canMove = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (fromTop)
        {
            other.transform.parent = objectToMove.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        other.transform.parent = null;
        fromTop = false;
    }
}
