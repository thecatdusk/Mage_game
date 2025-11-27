using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth = 5;

    public HeartsUI heartsUI;
    public GameObject gameOverUI;

    void Start()
    {   
        currentHealth = maxHealth;

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }

        if (heartsUI != null)
        {
            heartsUI.UpdateHearts(currentHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        if (heartsUI != null)
        {
            heartsUI.UpdateHearts(currentHealth);
        }

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        Time.timeScale = 0f;
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(1);
        }
    }
}