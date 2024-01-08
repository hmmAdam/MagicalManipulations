using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    int currentHealth;

    // You might want to use Start() to initialize the player's health
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Check if the player should be considered dead
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Perform actions for player death (e.g., game over, restart level, etc.)
        Debug.Log("Player died.");
        // For demonstration purposes, let's deactivate the player object
        gameObject.SetActive(false);
        // You might want to handle the game over scenario or other logic here
    }
}
