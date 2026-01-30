using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_StaminaController : MonoBehaviour
{

    [SerializeField] private Image _staminaBar;
    [SerializeField] private TextMeshProUGUI _staminaText;

    public void UpdateStaminaBar(float currentStamina, int maxStamina)
    {
        _staminaBar.fillAmount = currentStamina / maxStamina;
        _staminaText.text = $"ENERGY {(int)currentStamina}/{maxStamina}";
    }

}
