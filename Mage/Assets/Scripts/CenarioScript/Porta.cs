using UnityEngine;

public class Porta : MonoBehaviour
{
    public bool ativada = false;
    public GameObject hitBox;
    public Salas sala;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ativada)
        {
            hitBox.SetActive(true);
           
        }
        else
        {
            hitBox.SetActive(false);
        }

        if (sala.ativada && !sala.concluida)
        {
           ativada = true;

        }
        else
        {
            ativada = false;
        }
    }
}
