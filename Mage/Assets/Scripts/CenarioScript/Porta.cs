using UnityEngine;

public class Porta : MonoBehaviour
{
    public bool ativada = false;
    public Transform posicao;
    public Salas sala;
    public float altura = 0;
    public float alturaAberta = 10;
    public float alturaFechada = 0;
    public Vector3 velocidade = new Vector3(0,20,0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        altura = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        if (ativada)
        {
           if(altura > alturaFechada)
            {
                posicao.position = posicao.position - Time.deltaTime * velocidade;
                altura = altura - Time.deltaTime * 20;
            }
           
        }
        else
        {
            if(altura < alturaAberta)
            {
                posicao.position = posicao.position + Time.deltaTime * velocidade;
                altura = altura + Time.deltaTime * 20;
            }
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
