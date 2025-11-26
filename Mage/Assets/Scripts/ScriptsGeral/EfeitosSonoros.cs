using UnityEngine;
using UnityEngine.Audio;

public class EfeitosSonoros : MonoBehaviour
{
    public AudioSource tocadorDeSom;

    void Update()
    {
        if (!tocadorDeSom.isPlaying && tocadorDeSom.resource != null)
        {
            Destroy(gameObject);
        }
    }
    public void TocarSom(AudioResource som)
    {     
            tocadorDeSom.resource = som;
            tocadorDeSom.Play();
    }
}
