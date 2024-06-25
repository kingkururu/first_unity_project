using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // These are the Scene names. Make sure to set them in the Inspector window.
    //public string myFirstScene, mySecondScene;

    private string nextButton = "Reload";
    private static bool created = false;
    private Rect buttonRect;
    private int width, height;

    void Awake()
    {
        // Ensure the script is not deleted while loading.
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }

        // Specify the items for each scene.
        Camera.main.clearFlags = CameraClearFlags.SolidColor;
        width = Screen.width;
        height = Screen.height;
        buttonRect = new Rect(  width - (width / 7), 
                                height / 20, 
                                width / 8, 
                                height / 10);
    }

    void OnGUI()
    {
        // Return the current Active Scene in order to get the current Scene name.
        Scene firstScene = SceneManager.GetSceneByBuildIndex(0);
        Scene thisScene = SceneManager.GetActiveScene();
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        int nextSceneIndex = 0;
        
        if (sceneCount > 1)
        {
            nextButton = "Next";
        }
        
        if (thisScene.buildIndex != sceneCount - 1)
        {
            nextSceneIndex = thisScene.buildIndex + 1;
        }
        else
        {
            nextSceneIndex = 0;
        }

        // Display the button used to swap scenes.
        GUIStyle buttonStyle = new GUIStyle(GUI.skin.GetStyle("button"));
        buttonStyle.alignment = TextAnchor.MiddleCenter;
        buttonStyle.fontSize = 8 * (width / 200);

        if (GUI.Button(buttonRect, nextButton, buttonStyle))
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}