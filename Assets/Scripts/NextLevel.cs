using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class NextLevel : MonoBehaviour
    {
        public string nextLevelName;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                SceneManager.LoadScene(nextLevelName);
            }
        }
    }
}
