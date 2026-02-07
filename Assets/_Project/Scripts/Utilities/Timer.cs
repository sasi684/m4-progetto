using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    [SerializeField] private int _totalLevelTime; // Time until defeat different for each level
    [SerializeField] private UnityEvent<float> _onTimeChanged;  // Event used to update the UI

    private float _currentTimeLeft; // To keep track of the time left and display it in the UI

    private void Start()
    {
        _currentTimeLeft = _totalLevelTime;
    }

    private void Update()
    {
        if (_currentTimeLeft > 0) // Keep updating the UI and the timer each frame and load the defeat scene if it goes to zero
        {
            _currentTimeLeft -= Time.deltaTime;
            _onTimeChanged.Invoke(_currentTimeLeft);
        }
        else
            SceneManager.LoadScene("Defeat Scene");
    }

    public void AddTime(float time) // Used from coins to add extra time left
    {
        _currentTimeLeft += time;
    }

}
