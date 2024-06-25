using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousPlatform : MonoBehaviour
{
    public float timeBeforeFall = 1f;
    public Color warningColor;
    public bool freezeX = true;
    public bool freezeY = true;
    public bool freezeZ = true;
    public bool disappearing = false;
    
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            spriteRenderer.color = warningColor;
            Invoke("DropPlatform", timeBeforeFall);
        }
    }

    void DropPlatform()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
            
        if (freezeX && freezeY && freezeZ)
        {
            rb.constraints =    RigidbodyConstraints2D.FreezePositionX | 
                                RigidbodyConstraints2D.FreezePositionY |
                                RigidbodyConstraints2D.FreezeRotation;
        }
        else if (freezeX && freezeY)
        {
            rb.constraints =    RigidbodyConstraints2D.FreezePositionX |
                                RigidbodyConstraints2D.FreezePositionY;
        }
        else if (freezeX && freezeZ)
        {
            rb.constraints =    RigidbodyConstraints2D.FreezePositionX |
                                RigidbodyConstraints2D.FreezeRotation;
        }
        else if (freezeY && freezeZ)
        {
            rb.constraints =    RigidbodyConstraints2D.FreezePositionY |
                                RigidbodyConstraints2D.FreezeRotation;
        }
        else if (freezeX)
        {
            rb.constraints =    RigidbodyConstraints2D.FreezePositionX;
        }
        else if (freezeY)
        {
            rb.constraints =    RigidbodyConstraints2D.FreezePositionY;
        }
        else if (freezeZ)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
        if (disappearing)
        {
            Destroy(gameObject);
        }
    }
}
