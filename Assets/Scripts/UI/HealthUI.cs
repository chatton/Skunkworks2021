using TMPro;
using UnityEngine;

namespace UI
{
    public class HealthUI : MonoBehaviour
    {
        private TextMeshProUGUI text;
        private Health playerHealth;

        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
            playerHealth = FindObjectOfType<Player>().GetComponent<Health>();
        }

        private void Start()
        {
            playerHealth.OnTakeDamage += UpdateUI;
            playerHealth.OnDeath += UpdateUI;
        }

        private void UpdateUI(Health health)
        {
            text.text = $"Health {health.CurrentHealth}/{health.MaxHealth}";
        }
    }
}