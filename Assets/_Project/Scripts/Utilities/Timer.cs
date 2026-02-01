using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    [SerializeField] private int _totalLevelTime;
    [SerializeField] private UnityEvent<float> _onTimeChanged;

    private float _currentTimeLeft;

    private void Start()
    {
        _currentTimeLeft = _totalLevelTime;
    }

    private void Update()
    {
        if (_currentTimeLeft > 0)
        {
            _currentTimeLeft -= Time.deltaTime;
            _onTimeChanged.Invoke(_currentTimeLeft);
        }
        else
            SceneManager.LoadScene("Defeat Scene");
    }

    public void AddTime(float time)
    {
        _currentTimeLeft += time;
    }

}
