using UnityEngine;
using UnityEngine.SceneManagement;

public class Trocadecena : MonoBehaviour
{
    [SerializeField] private float tempoDeEspera = 15f; // tempo em segundos
    [SerializeField] private string proximaCena; // nome da próxima cena

    void Start()
    {
        Invoke("CarregarProximaCena", tempoDeEspera);
    }

    void CarregarProximaCena()
    {
        SceneManager.LoadScene(proximaCena);
    }
}
