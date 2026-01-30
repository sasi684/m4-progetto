using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{

    [SerializeField] private int _currentHP;
    [SerializeField] private int _maxHP;
    [SerializeField] private UnityEvent<int, int> _onHealthchanged;

    private void Start()
    {
        _currentHP = _maxHP;
        _onHealthchanged.Invoke(_currentHP, _maxHP);
    }

    public void TakeDamage(int damage)
    {
        _currentHP -= damage;

        if (_currentHP <= 0)
        {
            Debug.Log($"{gameObject.name} non ha piu' HP");
            Destroy(gameObject);
        }

        _onHealthchanged.Invoke(_currentHP, _maxHP);
    }

    public void AddHP(int amount) => TakeDamage(-amount);

}
