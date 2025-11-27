using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    // Variáveis de Status
    public float tempoInvulnerabilidade = 1f;
    private float timerInvulnerabilidade = 0f;
    public float vidaMax = 5;
    private float vidaAtual;
    public float manaMax = 100;
    public float manaAtual;
    public HeartsUI heartsUI;
    public Telas telas;

    // Variáveis de Movimento
    public CharacterController controle;
    public float speed = 12f;
    public float alturaPulo = 3f;

    // Variáveis de Gravidade
    Vector3 velocidade;
    public float gravidade = -19.62f;
    public Transform checarChao;
    public float distanciaChao = 0.4f;
    public LayerMask camadaChao;
    public bool estaNoChao;

    // Variáveis de Tiro
    public Transform mira;

    // Variaveis da Magia "Disparo Arcano"
    public GameObject disparoArcano;
    public float cooldownDisparoArcano = 0.4f;
    public float timerDisparoArcano = 0f;
    public AudioResource somDisparoArcano;

    // Variáveis da Magia Especial Selecionada
    public enum MagiaEspecialSelecionada {Nenhuma, BolaDeFogo, DisparoCongelante}
    public MagiaEspecialSelecionada magiaSelecionada = MagiaEspecialSelecionada.Nenhuma;

    // Variáveis da Magia Especial "Bola de Fogo"
    public AudioResource somBolaDeFogo;
    public GameObject bolaDeFogo;
    public bool bolaDeFogoLiberado = false;
    public float cooldownBolaDeFogo = 20f;
    public float timerBolaDeFogo = 0f;
    public float custoBolaDeFogo = 10f;
    public GameObject efeitoBolaFogo;

    // Variáveis da Magia Especial "Disparo Congelante"
    public GameObject disparoCongelante;
    public bool disparoCongelanteLiberado = false;
    public float cooldownDisparoCongelante = 5f;
    public float timerDisparoCongelante = 0f;
    public float custoDisparoCongelante = 5f;
    public GameObject efeitoDisparoCongelante;
    public AudioResource somDisparoCongelante;
    

    public GameObject tocadorDeSom;

    void Start()
    {
        vidaAtual = vidaMax;
        manaAtual = manaMax;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (telas.painelEscAtivo)
            {
                telas.DespausarJogo();
            }
            else
            {
                telas.PausarJogo();
            }
        }
    }

    void FixedUpdate()
    {
        Timers();

        // Botão de Ataque
        if (Input.GetButton("Fire1"))
        {
            DisparoArcano();
        }

        // Botão da Magia Especial
        if (Input.GetButton("Fire2"))
        {
            switch (magiaSelecionada) 
            {
                case MagiaEspecialSelecionada.BolaDeFogo:
                    BolaDeFogo();
                break;
                case MagiaEspecialSelecionada.DisparoCongelante:
                    DisparoCongelante();
                break;
            }
        }

        // Botão para selecionar a Magia Especial "Bola de Fogo"
        if (Input.GetKey(KeyCode.Alpha1))
        {
            TrocarBolaDeFogo();
        }

        // Botão para selecionar a Magia Especial "Disparo Congelante"
        if (Input.GetKey(KeyCode.Alpha2))
        {
            TrocarDisparoCongelante();
        }

        Movimentacao();

        
    }

    // Método de Movimento
    void Movimentacao()
    {
        // Verifica se o Jogador está encostado no chão
        estaNoChao = Physics.CheckSphere(checarChao.position, distanciaChao, camadaChao);

        // Reseta a velocidade de queda
        if (estaNoChao && velocidade.y < 0)
        {
            velocidade.y = -2f;
        }

        // Movimento
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 mover = transform.right * x + transform.forward * z;
        controle.Move(mover * speed * Time.deltaTime);

        // Pulo
        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            velocidade.y = Mathf.Sqrt(alturaPulo * -2 * gravidade);
        }

        // Gravidade
        velocidade.y += gravidade * Time.deltaTime;
        controle.Move(velocidade * Time.deltaTime);
    }

    // Método para trocar de magia para "Bola de Fogo" 
    void TrocarBolaDeFogo()
    {
        if (bolaDeFogoLiberado)
        {
            magiaSelecionada = MagiaEspecialSelecionada.BolaDeFogo;
        }
    }

    // Método para liberar a magia "Bola de Fogo"
    public void LiberaBolaDeFogo()
    {
        bolaDeFogoLiberado = true;
        TrocarBolaDeFogo();
    }

    // Método para trocar de magia para "Disparo Congelante"
    void TrocarDisparoCongelante()
    {
        if (disparoCongelanteLiberado)
        {
            magiaSelecionada = MagiaEspecialSelecionada.DisparoCongelante;
        }
    }

    // Método para liberar a magia "Disparo Congelante"
    public void LiberaDisparoCongelante()
    {
        disparoCongelanteLiberado = true;
        TrocarDisparoCongelante();
    }

    // Método da Magia "Disparo Arcano"
    void DisparoArcano()
    {
        if (timerDisparoArcano <= 0)
        {
            GameObject tocadorDeSomInstanciada = Instantiate(tocadorDeSom, mira.position, mira.rotation);
            tocadorDeSomInstanciada.GetComponent<EfeitosSonoros>().TocarSom(somDisparoArcano);
            GameObject disparoArcanoInstanciado = Instantiate(disparoArcano, mira.position, mira.rotation);
            disparoArcanoInstanciado.GetComponent<DisparoArcano>().PegarJogador(gameObject.GetComponent<Player>());
            timerDisparoArcano = cooldownDisparoArcano;
        }
    }

    // Método da Magia Especial "Bola de Fogo"
    void BolaDeFogo() 
    {
        if(timerBolaDeFogo <= 0 && bolaDeFogoLiberado && manaAtual >= custoBolaDeFogo) 
        {
            GameObject tocadorDeSomInstanciada = Instantiate(tocadorDeSom, mira.position, mira.rotation);
            tocadorDeSomInstanciada.GetComponent<EfeitosSonoros>().TocarSom(somBolaDeFogo);
            GameObject efeitoBolaFogoInstanciada = Instantiate(efeitoBolaFogo, mira.position, mira.rotation);
            GameObject bolaDeFogoInstanciada = Instantiate(bolaDeFogo, mira.position, mira.rotation);
            timerBolaDeFogo = cooldownBolaDeFogo;
            manaAtual -= custoBolaDeFogo;
        }
    }

    // Método da Magia Especial "Disparo Congelante"
    void DisparoCongelante()
    {
        if(timerDisparoCongelante <= 0 && disparoCongelanteLiberado && manaAtual >= custoDisparoCongelante)
        {
            GameObject tocadorDeSomInstanciada = Instantiate(tocadorDeSom, mira.position, mira.rotation);
            tocadorDeSomInstanciada.GetComponent<EfeitosSonoros>().TocarSom(somDisparoCongelante);
            GameObject efeitoCongelanteInstanciado = Instantiate(efeitoDisparoCongelante, mira.position, mira.rotation);
            GameObject disparoCongelanteInstanciado = Instantiate(disparoCongelante, mira.position, mira.rotation);
            timerDisparoCongelante = cooldownDisparoCongelante;
            manaAtual -= custoDisparoCongelante;
        }
    }

    // Método de Timers
    void Timers()
    {
        if(timerDisparoArcano > 0)
        {
            timerDisparoArcano -= Time.deltaTime;
        }
        if(timerInvulnerabilidade > 0)
        {
            timerInvulnerabilidade -= Time.deltaTime;
        }
        if(timerDisparoCongelante > 0)
        {
            timerDisparoCongelante -= Time.deltaTime;
        }
        if(timerBolaDeFogo > 0)
        {
            timerBolaDeFogo -= Time.deltaTime;
        }
    }

    // Método para recuperar vida
    public void RecuperaVida(float vidaRecuperada)
    {
        if (vidaRecuperada + vidaAtual > vidaMax) 
        {
            vidaAtual = vidaMax;
            heartsUI.UpdateHearts(vidaAtual);
        }
        else
        {
            vidaAtual += vidaRecuperada;
            heartsUI.UpdateHearts(vidaAtual);
        }
    }

    // Método para recuperar mana
    public void RecuperarMana(float manaRecuperada)
    {
        if(manaRecuperada + manaAtual > manaMax)
        {
            manaAtual = manaMax;
        }
        else
        {
            manaAtual += manaRecuperada;
        }
    }

    // Método de Tomar Dano
    public void TomarHit()
    {
        if(timerInvulnerabilidade <= 0)
        {
            vidaAtual--;
            if(vidaAtual > 0)
            {
                timerInvulnerabilidade = tempoInvulnerabilidade;
                heartsUI.UpdateHearts(vidaAtual);
            }
            else
            {
                Morte();
            }
        }
    }

    // Método que é Chamado Quando o Player Morre
    void Morte()
    {       
        telas.Fimdejogo();        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
   public void Vitoria()
    {
        telas.Win();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
