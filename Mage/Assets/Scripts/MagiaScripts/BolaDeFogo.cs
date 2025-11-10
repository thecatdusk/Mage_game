using UnityEngine;

public class BolaDeFogo : MonoBehaviour
{
    // Variáveis da Magia
    public float dano = 20f;
    public float velocidade = 40f;
    public float raioExplosao = 12.5f;
    public Transform posicao;
    public Rigidbody rb;

    // Variável de auto destruição
    public float timerDestruicao = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        // Movimento
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

    private void OnTriggerEnter(Collider other)
    {
        // Armazena a referência de todos que estão dentro da explosão e aplica a função de dano neles
        Collider[] colisores = Physics.OverlapSphere(posicao.position, raioExplosao);
        foreach (Collider col in colisores) 
        {
            if (col.CompareTag("Player")) 
            {
               
                col.GetComponent<Player>().TomarHit();

            }else if(col.CompareTag("Esqueleto Guerreiro"))
            {
               
                col.GetComponent<EsqueletoGuerreiro>().TomarHit(dano);

            }else if(col.CompareTag("Esqueleto Arqueiro"))
            {
                col.GetComponent<EsqueletoArqueiro>().TomarHit(dano);
            }
        }

        // Destroi o objeto da bola de fogo
        Destroy(gameObject);
    }
}
