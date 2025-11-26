using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class Musica : MonoBehaviour
{
    public Telas telas;
    public AudioResource musicaVitoria;
    public AudioResource musicaDerrota;
    public AudioResource musicaFundo;
    public AudioSource tocadorDeMusica;
    public Slider sliderVolume;
    public float passoVolume = 0.1f;

    void Start()
    {
        if (sliderVolume != null)
            tocadorDeMusica.volume = sliderVolume.value;
    }

    void Update()
    {
        if (telas.painelWinAtivo)
        {
            TrocarMusica(musicaVitoria);
        }
        else if (telas.painelFimdejogoAtivo)
        {
            TrocarMusica(musicaDerrota);
        }
        else
        {
            TrocarMusica(musicaFundo);
        }
    }

    void TrocarMusica(AudioResource musica)
    {
        if (tocadorDeMusica.resource != musica)
        {
            tocadorDeMusica.resource = musica;
            tocadorDeMusica.Play();
        }
    }

    public void AjustarVolume(float valor)
    {
        tocadorDeMusica.volume = valor;
    }

    public void DiminuirVolume()
    {
        float novo = Mathf.Clamp(tocadorDeMusica.volume - passoVolume, 0f, 1f);
        tocadorDeMusica.volume = novo;
        sliderVolume.value = novo;
    }

    public void AumentarVolume()
    {
        float novo = Mathf.Clamp(tocadorDeMusica.volume + passoVolume, 0f, 1f);
        tocadorDeMusica.volume = novo;
        sliderVolume.value = novo;
    }
}
