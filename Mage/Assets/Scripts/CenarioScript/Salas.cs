using UnityEngine;

public class Salas : MonoBehaviour
{
    public bool ativada = false;
    public bool concluida = false;
    public int contadorInimigo = 1;
    public BoxCollider colisor;
    public Player player;


    private void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            ativada = true;
            player = hit.GetComponent<Player>();
        }
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int contadorInimigoTemporario = 0;

        Collider[] colisores = Physics.OverlapBox(gameObject.transform.position, colisor.size);
        foreach (Collider col in colisores)
        {

            if (col.CompareTag("Esqueleto Guerreiro"))
            {
                contadorInimigoTemporario++;

            }
            else if (col.CompareTag("Esqueleto Arqueiro"))
            {
                contadorInimigoTemporario++;
            }
        }
        contadorInimigo = contadorInimigoTemporario;


        if (contadorInimigo > 0)
        {
            concluida = false;
        }
        else
        {
            concluida = true;
        }
    }
}
