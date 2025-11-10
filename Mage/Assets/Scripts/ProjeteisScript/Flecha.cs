using UnityEngine;

public class Flecha : MonoBehaviour
{
    // Variáveis da Flecha
    public float velocidade = 50f;
    public Transform posicao;

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
        if (hit.CompareTag("Player"))
        {
            hit.GetComponent<Player>().TomarHit();
        
        }
 
        Destroy(gameObject);
    }
}
