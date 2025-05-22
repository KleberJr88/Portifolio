using UnityEngine;

public class CrazyCamera : MonoBehaviour
{
    public Transform player;  // Referência ao transform do jogador
    public Vector3 offset = new Vector3(0, 5, -10);  // Distância fixa da câmera em relação ao jogador
    public float smoothSpeed = 0.125f;  // A velocidade com que a câmera segue o jogador

    private void LateUpdate()
    {
        if (player != null)
        {
            // Calcula a posição desejada (baseada na posição do jogador + o offset)
            Vector3 desiredPosition = player.position + offset;

            // Suaviza a movimentação da câmera para evitar movimentos bruscos
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Define a posição da câmera
            transform.position = smoothedPosition;

            // Faz a câmera olhar para o jogador
            transform.LookAt(player);
        }
    }
}