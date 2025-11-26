using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillContainer : MonoBehaviour
{
    public Player player;
    public GameObject skillBolaFogo;
    public GameObject skillDisparoCongelante;
    public bool bolaDeFogoAtivo = false;
    public bool disparoCongelanteAtivo = false;

    void Start()
    {
        bolaDeFogoAtivo = player.bolaDeFogoLiberado;
        disparoCongelanteAtivo = player.disparoCongelanteLiberado;
    }

    void Update()
    {
        bolaDeFogoAtivo = player.bolaDeFogoLiberado;
        disparoCongelanteAtivo = player.disparoCongelanteLiberado;
        skillBolaFogo.SetActive(bolaDeFogoAtivo);
        skillDisparoCongelante.SetActive(disparoCongelanteAtivo);
    }
}
