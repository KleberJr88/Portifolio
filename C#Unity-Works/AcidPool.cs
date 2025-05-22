using UnityEngine;

public class AcidPool : MonoBehaviour
{
    [Header("Referências")]
    public Transform dropPoint; 
    public string playerTag = "player";

    [Header("Piscinas de Ácido")]
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
            Debug.Log("O jogador caiu no ácido! Resetando posição...");
            other.transform.position = dropPoint.position; 
        }
    }

}