
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public int count = 0; // Initialize count to 0
    public int numImages = 8; // Number of images to loop through
    private GameObject[] imageObjects; // Array to hold references to the image GameObjects

    void Start()
    {
        // Find and store references to all image GameObjects
        imageObjects = new GameObject[numImages];
        for (int i = 0; i < numImages; i++)
        {
            imageObjects[i] = GameObject.Find("img" + i);
        }

        StartCoroutine(GetRoutine());
    }

    public IEnumerator GetRoutine()
    {
        while (true)
        {
            // Check if imageObjects array is initialized
            if (imageObjects == null || imageObjects.Length == 0)
            {
                Debug.LogError("imageObjects array is not initialized or empty.");
                yield break; // Exit the coroutine if imageObjects is not properly initialized
            }

            // Enable the current image
            if (count >= 0 && count < imageObjects.Length && imageObjects[count] != null)
            {
                Image imageComponent = imageObjects[count].GetComponent<Image>();
                if (imageComponent != null)
                {
                    imageComponent.enabled = true;
                }
                else
                {
                    Debug.LogWarning("Image component not found on current image object.");
                    yield break; // Exit the coroutine if there's an issue
                }
            }
            else
            {
                Debug.LogWarning("Current image not found or count out of range.");
                yield break; // Exit the coroutine if there's an issue
            }

            // Disable the previous image
            int previousCount = (count - 1 + numImages) % numImages;
            if (previousCount >= 0 && previousCount < imageObjects.Length && imageObjects[previousCount] != null)
            {
                Image previousImageComponent = imageObjects[previousCount].GetComponent<Image>();
                if (previousImageComponent != null)
                {
                    previousImageComponent.enabled = false;
                }
                else
                {
                    Debug.LogWarning("Image component not found on previous image object.");
                    yield break; // Exit the coroutine if there's an issue
                }
            }
            else
            {
                Debug.LogWarning("Previous image not found or previous count out of range.");
                yield break; // Exit the coroutine if there's an issue
            }

            // Increment count and wrap around using modulo
            count = (count + 1) % numImages;

            // Wait for 0.15 seconds
            yield return new WaitForSeconds(0.15f);
        }
    }

} // End of class Intro