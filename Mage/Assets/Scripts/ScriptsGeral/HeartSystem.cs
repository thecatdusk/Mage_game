using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HeartSystem : MonoBehaviour
{
    public int maxHearts = 3;
    public int currentLife = 6;

    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    public GameObject heartPrefab;        
    public Transform heartsContainer;    

    private List<Image> heartsList = new List<Image>();

    void Start()
    {
        CreateHearts();
        UpdateHearts();
    }

    void CreateHearts()
    {
        for (int i = 0; i < maxHearts; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartsContainer);
            Image img = heart.GetComponent<Image>();
            heartsList.Add(img);
        }
    }

    public void UpdateHearts()
    {
        int life = currentLife;

        for (int i = 0; i < maxHearts; i++)
        {
            if (life >= 2)
            {
                heartsList[i].sprite = fullHeart;
            }
            else if (life == 1)
            {
                heartsList[i].sprite = halfHeart;
            }
            else
            {
                heartsList[i].sprite = emptyHeart;
            }

            life -= 2;
        }
    }
}
