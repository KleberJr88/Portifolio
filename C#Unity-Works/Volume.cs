using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour

{

    public Slider volumeSlider;   // Refer�ncia para o Slider que controla o volume
    public AudioSource audioSource;  // Refer�ncia para o AudioSource que voc� deseja controlar

    void Start()
    {
        // Configurar o valor inicial do slider para o volume atual do AudioSource
        volumeSlider.value = audioSource.volume;

        // Adicionar um listener para detectar mudan�as no valor do slider
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }


    // M�todo chamado quando o valor do slider � alterado
    void OnVolumeChanged(float volume)
    {
        // Ajustar o volume do AudioSource baseado no valor do slider
        audioSource.volume = volume;
    }

}
