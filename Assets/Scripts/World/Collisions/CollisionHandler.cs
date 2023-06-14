using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float reloadDelay = 2f;
    // don't need start and update for this script
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly");
                break;
            case "Finish":
                LoadNextScene();
                break;
            default:
                // invoke allows for delay of method call
                EndLevelProcess();
                break;
        }
    }
    void EndLevelProcess()
    {
        GetComponent<PlayerMovement>().enabled = false;
        Invoke("SceneReload", reloadDelay);
    }
    void SceneReload()
    {
        // get current scene and set it as the scene to be reloaded
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextScene()
    {
        // get current scene and set it as the scene to be reloaded
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)// reset scene index if scene count is maxed
        {
            Debug.Log("scene reset");
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
