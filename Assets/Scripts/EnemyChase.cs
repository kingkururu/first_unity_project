using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyChase : MonoBehaviour
{
    private bool chasePlayer = false;
    private GameObject target;
    private Vector3 home;
    public float speed = 3f;
    public float lostPlayerPause = 3f;
    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        home = gameObject.transform.position;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.gameObject;
            chasePlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canMove = false;
            Invoke("GoHome", lostPlayerPause);
        }
    }

    void GoHome()
    {
        chasePlayer = false;
        canMove = true;
    }

    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        
        if (canMove)
        {
            if (chasePlayer)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.gameObject.transform.position, step);
            }
            else if (gameObject.transform.position != home)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, home, step);
            }
        }
    }
}
