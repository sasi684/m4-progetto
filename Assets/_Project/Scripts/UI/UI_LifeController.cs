using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_LifeController : MonoBehaviour
{

    [SerializeField] private Image _healthBar;
    [SerializeField] private TextMeshProUGUI _healthText;

    public void UpdateHealthBar(int currentHP, int maxHP)
    {
        _healthBar.fillAmount = (float)currentHP / maxHP;
        _healthText.text = $"HEALTH {currentHP}/{maxHP}";
    }

}
