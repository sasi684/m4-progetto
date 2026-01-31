using UnityEngine;

public class CoinAnimation : MonoBehaviour
{

    [SerializeField] private float _rotationSpeed;

    private CoinManager _coinManager;

    private void Awake()
    {
        _coinManager = FindAnyObjectByType<CoinManager>();
    }

    private void Update()
    {
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * _rotationSpeed * Time.deltaTime);
        transform.rotation = transform.rotation * deltaRotation;
    }

}
