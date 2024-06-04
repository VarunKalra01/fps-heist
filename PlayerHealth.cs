using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealthText();
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void HealToMax()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        healthText.text = "Health: \n" + currentHealth + " / " + maxHealth;
    }

    void Die()
    {
        // Handle player death (e.g., respawn, game over screen)
        Debug.Log("Player Died!");
    }
}
