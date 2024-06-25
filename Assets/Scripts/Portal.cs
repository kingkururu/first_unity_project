using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal destinationPortal;
    public bool isActive = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isActive)
        {
            if (destinationPortal != null)
            {
                destinationPortal.isActive = false;
                other.gameObject.transform.position = destinationPortal.transform.position;

                if (other.tag == "Player")
                {
                    Camera camera = Camera.main;
                    camera.transform.position = other.gameObject.transform.position;
                }

                if (other.tag == "Item")
                {
                    other.transform.parent = null;
                }
            }
        }

        print(other.gameObject.name);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!isActive)
        {
            isActive = true;
        }
    }
}
