using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private float maxHealth = 10f;
    private float currentHealth;
    public MenuManager manager;
    private AudioManager am;
    private void Awake()
    {
        am = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void TakeDamage(float amount = 1f)
    {
        currentHealth -= amount;
        healthBar.value = currentHealth;
        am.playclip(am.Damagedfx);
        CheckLoseCondition();
    }

    private void CheckLoseCondition()
    {
        if (currentHealth <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("Player Dead");
            manager.Death();
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void AddHealth(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        healthBar.value = currentHealth;
    }

}
