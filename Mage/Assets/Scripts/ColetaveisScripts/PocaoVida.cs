using UnityEngine;

public class PocaoVida : MonoBehaviour
{
    // Variável da recuperação de vida
    public float vida = 2f;
    
    void Start()
    {
        
    }

    void Update()
    {
     

    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            player.GetComponent<Player>().RecuperaVida(vida);
            Destroy(gameObject);
        }
    }
}
