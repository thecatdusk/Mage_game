using UnityEngine;
using UnityEngine.Audio;

public class DisparoCongelante : MonoBehaviour
{
    // Variáveis da Magia
    public float dano = 10f;
    public float tempoCongelamento = 1f;
    public float velocidade = 50f;
    public Transform posicao;
    public GameObject tocadorDeSom;
    public AudioResource somCongelando;

    // Variáveis de auto destruição
    public float timerDestruicao = 3f;

    void Start()
    {
        
    }

    void Update()
    {
        // Movimento do Disparo
        posicao.position += posicao.transform.forward * velocidade * Time.deltaTime;

        // Auto destruição
        if (timerDestruicao <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            timerDestruicao -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider hit)
    {
        GameObject tocadorDeSomInstanciada = Instantiate(tocadorDeSom, posicao.position, posicao.rotation);
        tocadorDeSomInstanciada.GetComponent<EfeitosSonoros>().TocarSom(somCongelando);

        if (hit.CompareTag("Esqueleto Guerreiro"))
        {
            hit.GetComponent<EsqueletoGuerreiro>().TomarHit(dano);
            hit.GetComponent<EsqueletoGuerreiro>().FicarCongelado(tempoCongelamento);
        }
        else if (hit.CompareTag("Esqueleto Arqueiro"))
        {           
            hit.GetComponent<EsqueletoArqueiro>().TomarHit(dano);
            hit.GetComponent<EsqueletoArqueiro>().FicarCongelado(tempoCongelamento);
        }
        Destroy(gameObject);
    }
}
