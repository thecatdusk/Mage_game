using UnityEngine;

public class HeartsUI : MonoBehaviour
{
    public GameObject[] heartIcons;

    public void UpdateHearts(float health)
    {
        for (int i = 0; i < heartIcons.Length; i++)
        {
            if (i < health)
            {
                if (heartIcons[i] != null)
                {
                    heartIcons[i].SetActive(true);
                }
            }
            else
            {
                if (heartIcons[i] != null)
                {
                    heartIcons[i].SetActive(false);
                }
            }
        }
    }
}