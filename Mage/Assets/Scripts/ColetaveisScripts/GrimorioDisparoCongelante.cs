using UnityEngine;

public class GrimorioDisparoCongelante : MonoBehaviour
{
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
            player.GetComponent<Player>().LiberaDisparoCongelante();
            Destroy(gameObject);
        }
    }

}
