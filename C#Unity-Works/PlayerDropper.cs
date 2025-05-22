using UnityEngine;

public class PlayerDropper : MonoBehaviour
{
    [Header("Configura��o de Drop")]
    public Transform dropLocation;
    public GameObject[] playerPrefabs; 

    private void Start()
    {
        DropPlayers();
    }

    void DropPlayers()
    {
        if (dropLocation == null || playerPrefabs.Length == 0)
        {
            Debug.LogWarning("DropLocation ou PlayerPrefabs n�o configurados!");
            return;
        }

        foreach (GameObject playerPrefab in playerPrefabs)
        {
            Instantiate(playerPrefab, dropLocation.position, Quaternion.identity);
        }
    }

}

