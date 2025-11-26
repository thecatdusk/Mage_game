using UnityEngine;

public class PocaoMana : MonoBehaviour
{
    // Variável do valor da mana recuperada
    public float mana = 50f;

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
            player.GetComponent<Player>().RecuperarMana(mana);
            Destroy(gameObject);
        }
    }
}
