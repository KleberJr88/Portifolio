using UnityEngine;

public class PlayerDropper : MonoBehaviour
{
    [Header("Configuração de Drop")]
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
            Debug.LogWarning("DropLocation ou PlayerPrefabs não configurados!");
            return;
        }

        foreach (GameObject playerPrefab in playerPrefabs)
        {
            Instantiate(playerPrefab, dropLocation.position, Quaternion.identity);
        }
    }

}

