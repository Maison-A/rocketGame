using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;
    [SerializeField] AudioClip soundCrash;
    [SerializeField] AudioClip soundSuccess;
    AudioSource asSource = null;
    bool isTransitioning = false;

    private void Start()
    {
        asSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) {return; }// break out if is Transitioning is set to true

        switch (other.gameObject.tag)
        {
            case "Finish":
                SuccessSequence();
                break;
            default:
                CrashSequence();
                break;
        }
    }

    /*
     * Name: CrashSequence
     * Desc: sequence of methods to be called & logic to be done when "crash" state is invoked after
     * player fails to reach goal - similar logic will be used in SuccessSequence()
     */
    void CrashSequence()
    {
        isTransitioning = true; // set transition state to true
        asSource.Stop(); // stop the source to prevent overlap
        asSource.PlayOneShot(soundCrash); // play sound set in enviornment editor

        GetComponent<PlayerMovement>().enabled = false; // disable player movement
        Invoke("SceneReload", loadDelay); // invoke allows for delay of method call
    }

    /*
     * Name: SuccessSequence
     * Desc: sequence of methods to be called & logic to be done when "success" state is invoked
     * after player reaches goal
     */
    void SuccessSequence()
    {
        isTransitioning = true;
        asSource.Stop();
        asSource.PlayOneShot(soundSuccess);
        
        GetComponent<PlayerMovement>().enabled = false;
        Invoke("LoadNextScene", loadDelay);
    }

    /*
     * Name: SceneReload
     * Desc: reload current scene by passing in active scene index
     */
    void SceneReload()
    {
        // get current scene and set it as the scene to be reloaded
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    /*
     * Name: LoadNextScene
     * Desc: load next scene after player "wins" current scene
     */
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
