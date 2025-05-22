using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public GameObject door;  // Drag the door in the editor
    public GameObject stone; // Drag the stone in the editor
    public GameObject altar; // Drag the altar in the editor
    public GameObject spear; // Drag the spear in the editor

    private bool hasStone = false;
    private bool altarUsed = false;
    private bool hasSpear = false; // Variable to check if the spear has been collected
    private GameObject objectToDestroy; // Store the object to destroy after triggering

    void Update()
    {
        // Checks if the player is near the stone and collects it
        if (IsNearObject(stone) && Input.GetKeyDown(KeyCode.Z))
        {
            hasStone = true;
            Destroy(stone); // Destroys the stone after collection
            Debug.Log("Stone collected!");
        }

        // Checks if the player is near the altar, has the stone, and the altar hasn't been used yet
        if (IsNearObject(altar) && hasStone && !altarUsed && Input.GetKeyDown(KeyCode.Z))
        {
            Destroy(door); // Opens the door
            altarUsed = true; // Marks that the altar has been used
            Debug.Log("Door opened!");
        }

        // Checks if the player is near the spear and collects it
        if (IsNearObject(spear) && !hasSpear && Input.GetKeyDown(KeyCode.Z))
        {
            hasSpear = true;
            Destroy(spear); // Destroys the spear after collection
            Debug.Log("Spear collected! 'Cut' ability unlocked.");
        }

        // Destroy the object with the 'Cut' ability if spear is collected and Z key is pressed
        if (hasSpear && objectToDestroy != null && Input.GetKeyDown(KeyCode.Z))
        {
            Destroy(objectToDestroy); // Destroys the object
            Debug.Log(objectToDestroy.name + " destroyed with 'Cut' ability!");
            objectToDestroy = null; // Reset the objectToDestroy after destruction
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasSpear && other.gameObject.CompareTag("Destroyable"))
        {
            objectToDestroy = other.gameObject; // Store the object for potential destruction
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Clear the object if the player leaves the trigger area
        if (other.gameObject == objectToDestroy)
        {
            objectToDestroy = null;
        }
    }

    bool IsNearObject(GameObject obj)
    {
        if (obj != null) // Checks if the object still exists
        {
            return Vector3.Distance(transform.position, obj.transform.position) < 2.0f; // Adjust the distance as needed
        }
        return false;
    }
}
