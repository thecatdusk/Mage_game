using UnityEngine;

public class SkillTela : MonoBehaviour
{
    public Player player;
    public GameObject iconeGelo;
    public GameObject iconeFogo;


    void Start()
    {

    }

    void Update()
    {
        switch (player.magiaSelecionada)
        {
            case Player.MagiaEspecialSelecionada.BolaDeFogo:
                iconeGelo.SetActive(false);
                iconeFogo.SetActive(true);
                break;
            case Player.MagiaEspecialSelecionada.DisparoCongelante:
                iconeGelo.SetActive(true);
                iconeFogo.SetActive(false);
                break;
            case Player.MagiaEspecialSelecionada.Nenhuma:
                iconeGelo.SetActive(false);
                iconeFogo.SetActive(false);

                break;
        }
    }
}