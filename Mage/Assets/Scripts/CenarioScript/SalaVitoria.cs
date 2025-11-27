using UnityEngine;

public class SalaVitoria : MonoBehaviour
{
    public BoxCollider colisor;
    public Player player;


    private void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            player = hit.GetComponent<Player>();
            player.Vitoria();
            Destroy(gameObject);
        }
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
