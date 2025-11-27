using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenController : MonoBehaviour
{
    public float timeToHide = 8f;

    void OnEnable()
    {
        Invoke("GoToMenu", timeToHide);
    }

    void GoToMenu()
    {
        SceneManager.LoadScene("Menu"); // nome exato da cena
    }
}
