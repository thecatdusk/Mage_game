using UnityEngine;
using UnityEngine.AI;

public class EsqueletoArqueiro : MonoBehaviour
{
    // Variáveis da Maquina de Estados
    public enum EstadoInimigo { Desativado, Perseguindo, Atacando, Ferido, Congelado, Morrendo };
    private EstadoInimigo estado = EstadoInimigo.Desativado;

    // Variáveis de Vida
    public float vidaMax = 15f;
    private float vidaAtual;

    // Variáveis de Ataque
    public float ataqueDelay = 2f;
    private float ataqueTimer = 0f;
    public float distanciaAtaque = 30f;

    // Variáveis de Ferido
    public float feridoDelay = 0.3f;
    private float feridoTimer = 0f;

    // Variáveis de Morrendo
    public float morrendoDelay = 0.3f;
    private float morrendoTimer = 0f;

    // Variável de Status
    private float congeladoTimer = 0f;

    // Variável de Movimento
    public NavMeshAgent nav;

    // Variáveis de Referência do Jogador
    public Player jogador;
    private float distanciaJogador;

    // Variáveis dos Drops
    public GameObject pocaoVida;
    public GameObject pocaoMana;
    public float chanceDrop = 10;

    // Variáveis da Flecha
    public GameObject flecha;
    public Transform miraArqueiro;

    public Animator animator;

    public Salas sala;

    void Start()
    {
        vidaAtual = vidaMax;
        animator.SetBool("Idle", true);
        animator.SetBool("Atacando", false);
        animator.SetBool("Morrendo", false);
        animator.SetBool("Perseguindo", false);
        animator.SetBool("Hit", false);
        animator.SetBool("Congelado", false);
    }


    void FixedUpdate()
    {
        if (sala.ativada)
        {
            AtivarInimigo();
        } 

        VerificarDistancia();
        switch (estado)
        {
            case EstadoInimigo.Desativado:

                break;
            case EstadoInimigo.Perseguindo:
                Perseguindo();
                break;
            case EstadoInimigo.Atacando:
                Atacando();
                break;
            case EstadoInimigo.Ferido:
                Ferido();
                break;
            case EstadoInimigo.Congelado:
                Congelado();
                break;
            case EstadoInimigo.Morrendo:
                Morrendo();
                break;
        }
    }

    // Método que verifica a distancia entre o Gerreiro Esqueleto e o Jogador
    void VerificarDistancia()
    {
        if (jogador != null)
        { 
            distanciaJogador = Vector3.Distance(jogador.transform.position, transform.position); 
        }
    }

    // Método que ativa o inimigo
    public void AtivarInimigo()
    {
        if (estado == EstadoInimigo.Desativado)
        {
            jogador = sala.player;
            estado = EstadoInimigo.Perseguindo;
        }
    }

        // Método que define o comportamento do inimigo caso o estado dele seja "Perseguindo"
        void Perseguindo()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Atacando", false);
        animator.SetBool("Morrendo", false);
        animator.SetBool("Perseguindo", true);
        animator.SetBool("Hit", false);
        animator.SetBool("Congelado", false);

        if (distanciaJogador > distanciaAtaque)
        {
            nav.isStopped = false;
            nav.SetDestination(jogador.transform.position);
        }
        else
        {
            ataqueTimer = ataqueDelay;
            estado = EstadoInimigo.Atacando;
        }

    }

    // Método que define o comportamento do inimigo caso o estado dele seja "Atacando"
    void Atacando()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Atacando", true);
        animator.SetBool("Morrendo", false);
        animator.SetBool("Perseguindo", false);
        animator.SetBool("Hit", false);
        animator.SetBool("Congelado", false);

        if (jogador != null)
        {
            gameObject.transform.LookAt(jogador.transform);

            if (ataqueTimer > 0)
            {
                nav.isStopped = true;
                ataqueTimer -= Time.deltaTime;
            }
            else
            {
                GameObject flechaInstanciado = Instantiate(flecha, miraArqueiro.position, miraArqueiro.rotation);

                if (distanciaJogador < distanciaAtaque)
                {

                    ataqueTimer = ataqueDelay;
                    estado = EstadoInimigo.Atacando;
                }
                else
                {
                    estado = EstadoInimigo.Perseguindo;
                }
            }
        
        }
    }

    // Método que define o comportamento do inimigo caso o estado dele seja "Ferido"
    void Ferido()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Atacando", false);
        animator.SetBool("Morrendo", false);
        animator.SetBool("Perseguindo", false);
        animator.SetBool("Hit", true);
        animator.SetBool("Congelado", false);

        if (feridoTimer > 0)
        {
            nav.isStopped = true;
            feridoTimer -= Time.deltaTime;
        }
        else
        {
            if (distanciaJogador < distanciaAtaque)
            {
                ataqueTimer = ataqueDelay;
                estado = EstadoInimigo.Atacando;
            }
            else
            {
                estado = EstadoInimigo.Perseguindo;
            }
        }
    }

    // Método que define o comportamento do inimigo caso o estado dele seja "Congelado"
    void Congelado()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Atacando", false);
        animator.SetBool("Morrendo", false);
        animator.SetBool("Perseguindo", false);
        animator.SetBool("Hit", false);
        animator.SetBool("Congelado", true);

        if (congeladoTimer > 0)
        {
            nav.isStopped = true;
            congeladoTimer -= Time.deltaTime;
        }
        else
        {
            if (distanciaJogador < distanciaAtaque)
            {
                ataqueTimer = ataqueDelay;
                estado = EstadoInimigo.Atacando;
            }
            else
            {
                estado = EstadoInimigo.Perseguindo;
            }
        }
    }

    // Método que define o comportamento do inimigo caso o estado dele seja "Morrendo"
    void Morrendo()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Atacando", false);
        animator.SetBool("Morrendo", true);
        animator.SetBool("Perseguindo", false);
        animator.SetBool("Hit", false);
        animator.SetBool("Congelado", false);

        if (morrendoTimer > 0)
        {
            nav.isStopped = true;
            morrendoTimer -= Time.deltaTime;
        }
        else
        {
            int rand = Mathf.RoundToInt(Random.Range(0, 100));
            if (rand <= chanceDrop)
            {
                if (Random.value < 0.5f)
                {
                    GameObject dropInstanciado = Instantiate(pocaoVida, gameObject.transform.position, gameObject.transform.rotation);
                }
                else
                {
                    GameObject dropInstanciado = Instantiate(pocaoMana, gameObject.transform.position, gameObject.transform.rotation);
                }
            }
            Destroy(gameObject);
        }
    }

    // Metodo que é acionado quando o inimigo toma um hit
    public void TomarHit(float dano)
    {
        if (estado != EstadoInimigo.Desativado)
        {
            vidaAtual -= dano;
            if (vidaAtual > 0)
            {
                if (congeladoTimer <= 0)
                {
                    feridoTimer = feridoDelay;
                    estado = EstadoInimigo.Ferido;
                }
            }
            else
            {
                morrendoTimer = morrendoDelay;
                estado = EstadoInimigo.Morrendo;
            }
        }
    }

    // Metodo que é acionado quando o inimigo é congelado
    public void FicarCongelado(float tempoCongelado)
    {
        if (estado != EstadoInimigo.Desativado)
        {
            congeladoTimer += tempoCongelado;
            estado = EstadoInimigo.Congelado;
        }
    }
}
