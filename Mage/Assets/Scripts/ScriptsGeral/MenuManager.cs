using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // Mantenha o Slider para o volume, caso você ainda queira usá-lo na tela de Opções.
    // **Torne-o público para poder arrastar o Slider no Inspector do Unity.**
    public Slider volumeSlider;

    // **Novo: Defina o incremento (o quanto o volume muda a cada clique do botão)**
    public float volumeStep = 0.1f; // Altere este valor no Inspector (ex: 0.1f = 10% por clique)

    void Start()
    {
        // O código de inicialização pode permanecer o mesmo
        if (PlayerPrefs.HasKey("soundVolume"))
        {
            LoadVolume();
        }
        else
        {
            // O volume padrão é 1.0 (máximo)
            PlayerPrefs.SetFloat("soundVolume", 1f);
            LoadVolume();
        }
    }

    // Função para definir o volume baseada no Slider (pode ser chamada no evento On Value Changed do Slider)
    public void SetVolume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }

    // --- NOVAS FUNÇÕES PARA BOTÕES ---

    // 🔊 Função para Aumentar o Volume
    public void IncreaseVolume()
    {
        // Obtém o volume atual e adiciona o passo, garantindo que não ultrapasse 1.0
        float newVolume = Mathf.Min(AudioListener.volume + volumeStep, 1.0f);

        // Aplica o novo volume
        AudioListener.volume = newVolume;

        // Atualiza o Slider para refletir a mudança (se ele existir na cena)
        if (volumeSlider != null)
        {
            volumeSlider.value = newVolume;
        }

        SaveVolume();
    }

    // 🔇 Função para Diminuir o Volume
    public void DecreaseVolume()
    {
        // Obtém o volume atual e subtrai o passo, garantindo que não seja inferior a 0.0
        float newVolume = Mathf.Max(AudioListener.volume - volumeStep, 0.0f);

        // Aplica o novo volume
        AudioListener.volume = newVolume;

        // Atualiza o Slider para refletir a mudança (se ele existir na cena)
        if (volumeSlider != null)
        {
            volumeSlider.value = newVolume;
        }

        SaveVolume();
    }

    // --- FUNÇÕES DE SALVAR/CARREGAR (inalteradas) ---

    // Função para Salvar o valor do volume no PlayerPrefs
    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("soundVolume", AudioListener.volume);
        PlayerPrefs.Save(); // É bom garantir que o PlayerPrefs seja salvo
    }

    // Função para Carregar o valor do volume
    public void LoadVolume()
    {
        // Carrega o valor do PlayerPrefs
        float savedVolume = PlayerPrefs.GetFloat("soundVolume");

        // Aplica ao AudioListener
        AudioListener.volume = savedVolume;

        // Se houver um Slider, atualize-o com o valor carregado
        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
        }
    }
}