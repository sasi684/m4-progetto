using TMPro;
using UnityEngine;

public class UI_CoinsCounter : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _coinsCounterText;

    public void OnCoinsCounterChanged(int coins, int maxCoins)
    {
        _coinsCounterText.text = $"{coins}/{maxCoins}";
    }

}
