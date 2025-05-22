using UnityEngine;

public class TrampolimBoost : MonoBehaviour
{
    [Header("Configura��o do Trampolim")]
    public float jumpBoost = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player")) 
        {
            Rigidbody playerRb = other.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                // Reseta a velocidade vertical do Player antes de aplicar o impulso
                playerRb.linearVelocity = new Vector3(playerRb.linearVelocity.x, 0f, playerRb.linearVelocity.z);

                // Aplica a for�a de impulso para cima
                playerRb.AddForce(Vector3.up * jumpBoost, ForceMode.Impulse);
            }
        }
    }
}
