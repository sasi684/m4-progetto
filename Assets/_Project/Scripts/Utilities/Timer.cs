using UnityEngine;
using UnityEngine.Events;

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
        _currentTimeLeft -= Time.deltaTime;
        _onTimeChanged.Invoke(_currentTimeLeft);
    }

    public void AddTime(float time)
    {
        _currentTimeLeft += time;
    }

}
