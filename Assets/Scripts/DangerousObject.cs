using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class DangerousObject : MonoBehaviour
    {
        public float lifeSpan = 5f;
        public bool isTemporary = false;

        private void Start()
        {
            if (isTemporary)
            {
                Invoke("DestroyObject", lifeSpan);
            }
        }

        private void DestroyObject()
        {
            Destroy(gameObject);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.transform.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
            }
        }
    }
}
