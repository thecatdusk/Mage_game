using UnityEngine;

public class GrimorioBolaDeFogo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            player.GetComponent<Player>().LiberaBolaDeFogo();
            Destroy(gameObject);
        }
    }
}
