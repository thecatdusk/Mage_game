using UnityEngine;

public class DisparoArcano : MonoBehaviour
{
    // Variáveis da Magia
    public float dano = 5;
    public float velocidade = 50f;
    public Transform posicao;

    // Variáveis de auto destruição
    public float timerDestruicao = 3f;

    // Variável de referência ao jogador
    public Player jogador;

    void Start()
    {
        
    }

    public void PegarJogador(Player jogador) {
        this.jogador = jogador;
    }

    void Update()
    {
        // Movimento do Disparo
        posicao.position += posicao.transform.forward * velocidade * Time.deltaTime;

        // Auto destruição
        if(timerDestruicao <= 0)
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
        if (hit.CompareTag("Esqueleto Guerreiro"))
        {
            hit.GetComponent<EsqueletoGuerreiro>().TomarHit(dano);
            jogador.RecuperarMana(1f);
        }
        else if (hit.CompareTag("Esqueleto Arqueiro"))
        {
            
        }
        Destroy(gameObject);
    }
}
