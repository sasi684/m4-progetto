using UnityEngine;

public class CoinSimple : MonoBehaviour
{

    private CoinManager _coinManager;

    private void Awake()
    {
        _coinManager = FindAnyObjectByType<CoinManager>();
        _coinManager.AddCoinToTotal();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.TryGetComponent<PlayerController>(out var player))
        {
            _coinManager.AddCoinToCounter();
            Destroy(gameObject);
        }
    }

}
