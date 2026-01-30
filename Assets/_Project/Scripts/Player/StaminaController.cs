using UnityEngine;
using UnityEngine.Events;

public class StaminaController : MonoBehaviour
{

    [SerializeField] private float _currentStamina;
    [SerializeField] private int _maxStamina;
    [SerializeField] private UnityEvent<float, int> _onStaminaChanged;

    private void Start()
    {
        _currentStamina = _maxStamina;
        _onStaminaChanged.Invoke(_currentStamina, _maxStamina);
    }

    public float GetCurrentStamina() => _currentStamina;

    public void ConsumeStamina(float consume)
    {
        _currentStamina -= consume;

        if (_currentStamina < 0)
            _currentStamina = 0;

        _onStaminaChanged.Invoke(_currentStamina, _maxStamina);
    }

    public void GainStamina(float gain)
    {
        if (_currentStamina < _maxStamina)
        {
            _currentStamina += gain;
            _onStaminaChanged.Invoke(_currentStamina, _maxStamina);
        }
    }

}
