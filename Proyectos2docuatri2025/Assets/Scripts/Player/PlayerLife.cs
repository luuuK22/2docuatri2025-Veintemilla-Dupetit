using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour, IDamageable
{
    public float maxHealth = 100f;
    public float currentHealth;

    [SerializeField] private Text healthText;

    public event Action<float> OnHealthChanged;

    private void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged += UpdateHealthText;
        NotifyHealthChange();
    }

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Max(currentHealth - amount, 0f);
        NotifyHealthChange();

       
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        NotifyHealthChange();
    }

    private void NotifyHealthChange()
    {
        OnHealthChanged?.Invoke(currentHealth);
    }

    private void UpdateHealthText(float health)
    {
        if (healthText != null)
            healthText.text = $"Vida: {health:0}";
    }

    private void Update()
    {
        Die();
    }

    private void Die()
    {
        if (currentHealth <= 0f)
        {
            SceneManager.LoadScene("Menu");
            Debug.Log("Mori");
        }
    }

  
}
