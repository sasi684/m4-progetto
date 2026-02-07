using UnityEngine;

public class CoinExtraTime : MonoBehaviour
{

    [SerializeField] private float _extraTime;
    
    private Timer _timer;
    private CoinManager _coinManager;

    private void Awake()
    {
        _timer = FindAnyObjectByType<Timer>();
        _coinManager = FindAnyObjectByType<CoinManager>();
    }

    private void Start()
    {
        _coinManager.AddCoinToTotal();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.TryGetComponent<PlayerController>(out var player))
        {
            _timer.AddTime(_extraTime);
            _coinManager.AddCoinToCounter();
            Destroy(gameObject);
        }
    }

}
