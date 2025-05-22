using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyLeaver : MonoBehaviour
{
    [Header("Referências")]
    public GameObject porta; 
    public GameObject triggerCena; 
    public string nomeCena; 

    private bool jogadorPerto = false;

    void Start()
    {
        // Garante que o trigger de cena começa desativado
        if (triggerCena != null)
            triggerCena.SetActive(false);
    }

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.Space))
        {
            AbrirPorta();
        }
    }

    void AbrirPorta()
    {
        if (porta != null)
            porta.SetActive(false); 

        if (triggerCena != null)
            triggerCena.SetActive(true); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            jogadorPerto = true;
        }
        else if (other.CompareTag("player") && triggerCena != null && triggerCena.activeSelf)
        {
            SceneManager.LoadScene(nomeCena); // Troca de cena ao entrar no trigger
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            jogadorPerto = false;
        }
    }
}
