using UnityEngine;
using UnityEngine.UI;

    public class ManaSlider : MonoBehaviour
    {
        public Player player;
        public Slider slider;

        void Start()
        {
            slider.value = 1f;
        }

        void Update()
        {
            slider.value = player.manaAtual / player.manaMax;
        }
    }
        