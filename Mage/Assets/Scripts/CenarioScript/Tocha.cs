using UnityEngine;

public class Tocha : MonoBehaviour
{
    public bool ativada = false;
    public float forcaLuz = 50f;
    public Light luz;
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
            luz.enabled = true;
            luz.range = forcaLuz;
        }
        else
        {
            luz.enabled = false;
        }

        if (sala.ativada)
        {
            ativada = true;
        }
        else
        {
            ativada = false;
        }
    }
}
