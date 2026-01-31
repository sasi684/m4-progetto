using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinManager : MonoBehaviour
{

    [SerializeField] private int _coinsCounter;
    [SerializeField] private UnityEvent<int> _onCoinsCounterChanged;

    private void Start()
    {
        _coinsCounter = 0;
        _onCoinsCounterChanged.Invoke(_coinsCounter);
    }

    public void AddCoin()
    {
        _coinsCounter++;
        _onCoinsCounterChanged.Invoke(_coinsCounter);
    }

}
