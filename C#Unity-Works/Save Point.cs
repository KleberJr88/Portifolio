using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePoint : MonoBehaviour
{
    private Vector3 savedPosition; // To store the player's saved position
    private string savedSceneName; // To store the current scene name
    public GameObject player; // Reference to the player object

    void Start()
    {
        // Check if there is a previously saved position
        if (PlayerPrefs.HasKey("SavedX") && PlayerPrefs.HasKey("SavedY") && PlayerPrefs.HasKey("SavedZ"))
        {
            // Load the saved player position
            float savedX = PlayerPrefs.GetFloat("SavedX");
            float savedY = PlayerPrefs.GetFloat("SavedY");
            float savedZ = PlayerPrefs.GetFloat("SavedZ");

            // Load the position into the player when returning to the scene
            savedPosition = new Vector3(savedX, savedY, savedZ);
            player.transform.position = savedPosition;
        }

        // Check if the current scene is the one that was saved
        if (PlayerPrefs.HasKey("SavedScene"))
        {
            savedSceneName = PlayerPrefs.GetString("SavedScene");

            // If the player has returned to the scene where the Save Point is located
            if (savedSceneName == SceneManager.GetActiveScene().name)
            {
                player.transform.position = savedPosition;
            }
        }
    }

    // This method is called when the player reaches the Save Point
    public void SaveGame()
    {
        // Save the player's current position
        savedPosition = player.transform.position;
        PlayerPrefs.SetFloat("SavedX", savedPosition.x);
        PlayerPrefs.SetFloat("SavedY", savedPosition.y);
        PlayerPrefs.SetFloat("SavedZ", savedPosition.z);

        // Save the current scene name
        savedSceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("SavedScene", savedSceneName);

        // Save the data permanently
        PlayerPrefs.Save();

        Debug.Log("Game saved at position: " + savedPosition);
    }

    // This method should be called when switching scenes
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedScene"))
        {
            // Load the saved scene
            savedSceneName = PlayerPrefs.GetString("SavedScene");

            if (SceneManager.GetActiveScene().name != savedSceneName)
            {
                // Load the saved scene
                SceneManager.LoadScene(savedSceneName);
            }
        }
    }

    // Optional method to reset the saved data
    public void ResetSave()
    {
        PlayerPrefs.DeleteKey("SavedX");
        PlayerPrefs.DeleteKey("SavedY");
        PlayerPrefs.DeleteKey("SavedZ");
        PlayerPrefs.DeleteKey("SavedScene");

        Debug.Log("Save data reset.");
    }
}
