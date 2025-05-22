using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewTrigger : MonoBehaviour
{
    public string[] scenesToLoad; // Array to hold the names of scenes to choose from

    void Start()
    {
        Invoke("RandomlyLoadScene", Random.Range(5f, 120f)); // Invoke RandomlyLoadScene with a random delay between 5 seconds and 2 minutes
    }

    void RandomlyLoadScene()
    {
        // Check if there are scenes available to load
        if (scenesToLoad.Length > 0)
        {
            // Randomly select a scene from the array
            int randomIndex = Random.Range(0, scenesToLoad.Length);
            string sceneName = scenesToLoad[randomIndex];

            // Load the randomly selected scene
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("No scenes to load!");
        }

        // Schedule the next random scene load
        Invoke("RandomlyLoadScene", Random.Range(5f, 120f));
    }
}