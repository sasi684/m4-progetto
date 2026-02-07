using UnityEngine;
using UnityEngine.Events;

public class CoinManager : MonoBehaviour
{

    [SerializeField] private int _coinsCounter;
    [SerializeField] private UnityEvent<int, int> _onCoinsCounterChanged;

    private int _totalCoins;

    private void Awake()
    {
        _totalCoins = 0;
    }

    private void Start()
    {
        _coinsCounter = 0;
        _onCoinsCounterChanged.Invoke(_coinsCounter, _totalCoins);
    }

    public void AddCoinToTotal()
    {
        _totalCoins++;
        _onCoinsCounterChanged.Invoke(_coinsCounter, _totalCoins);
    }

    public void AddCoinToCounter()
    {
        _coinsCounter++;
        _onCoinsCounterChanged.Invoke(_coinsCounter, _totalCoins);
    }

}
