using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillBolaFogo : MonoBehaviour
{
    public Image cooldownMask;
    public Player player;


    void Start()
    {
        cooldownMask.fillAmount = 0f;
    }

    void Update()
    {
        float ratio = player.timerBolaDeFogo / player.cooldownBolaDeFogo;

        cooldownMask.fillAmount = ratio;
    }
}
