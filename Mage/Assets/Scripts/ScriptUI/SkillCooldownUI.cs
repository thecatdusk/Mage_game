using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillCooldownUI : MonoBehaviour
{
    public Image cooldownMask;
    public Player player;


    void Start()
    {
        cooldownMask.fillAmount = 0f;
    }

    void Update()
    {
        float ratio = player.timerDisparoCongelante / player.cooldownDisparoCongelante;
        cooldownMask.fillAmount = ratio;
    }
}
