using UnityEngine;
using UnityEngine.UI;

public abstract class Health : MonoBehaviour
{
    public float maxHealth = 100;
    [HideInInspector] public float currentHealth;
    [SerializeField] Slider healthSlider;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        healthSlider.value = Mathf.Lerp(healthSlider.value, currentHealth, Time.deltaTime);
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            Hit();
        }
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public abstract void Hit();
    public abstract void Die();
}
