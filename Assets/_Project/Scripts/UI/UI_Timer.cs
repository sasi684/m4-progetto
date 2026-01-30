using TMPro;
using UnityEngine;

public class UI_Timer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _timer;

    public void UpdateTimer(float timeLeft)
    {
        _timer.text = $"{(int)timeLeft}";
    }
}
