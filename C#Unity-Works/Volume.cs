using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour

{

    public Slider volumeSlider;   // Referência para o Slider que controla o volume
    public AudioSource audioSource;  // Referência para o AudioSource que você deseja controlar

    void Start()
    {
        // Configurar o valor inicial do slider para o volume atual do AudioSource
        volumeSlider.value = audioSource.volume;

        // Adicionar um listener para detectar mudanças no valor do slider
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }


    // Método chamado quando o valor do slider é alterado
    void OnVolumeChanged(float volume)
    {
        // Ajustar o volume do AudioSource baseado no valor do slider
        audioSource.volume = volume;
    }

}
