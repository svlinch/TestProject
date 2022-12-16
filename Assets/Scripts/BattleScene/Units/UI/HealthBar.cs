using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider _healthSlider;
    [SerializeField]
    private TextMeshProUGUI _healthText;

    public void UpdateHealth(int maxHealth, int currentHealth, int shield)
    {
        _healthSlider.value = (float)currentHealth / (float) maxHealth;
        var builder = new StringBuilder(currentHealth.ToString());
        if (shield > 0)
        {
            builder.Append(" + ");
            builder.Append(shield.ToString());
        }
        _healthText.text = builder.ToString();
    }
}
