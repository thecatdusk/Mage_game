using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour
{
    [SerializeField] private float tempoDeEspera = 15f; 
    [SerializeField] private string proximaCena; 

    void Start()
    {

    }

    void CarregarProximaCena()
    {
        SceneManager.LoadScene(proximaCena);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}

