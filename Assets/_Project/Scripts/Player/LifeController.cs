using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SceneManager.LoadScene("Defeat Scene");
        }

        _onHealthchanged.Invoke(_currentHP, _maxHP);
    }

    public void AddHP(int amount) => TakeDamage(-amount);

}
