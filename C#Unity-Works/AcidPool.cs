using UnityEngine;

public class AcidPool : MonoBehaviour
{
    [Header("Refer�ncias")]
    public Transform dropPoint; 
    public string playerTag = "player";

    [Header("Piscinas de �cido")]
    public GameObject[] acidPools; 

    private void Start()
    {
        // Collider Pool
        foreach (GameObject pool in acidPools)
        {
            Collider col = pool.GetComponent<Collider>();
            if (col != null)
            {
                col.isTrigger = true; 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Transport
        if (other.CompareTag(playerTag))
        {
            Debug.Log("O jogador caiu no �cido! Resetando posi��o...");
            other.transform.position = dropPoint.position; 
        }
    }

}