using UnityEngine;

public class SimpleBullet : MonoBehaviour
{

    [SerializeField] private int _damage;
    [SerializeField] private float _bulletDuration;
    [SerializeField] private float _bulletSpeed;

    private Vector3 _direction;

    private void Start()
    {
        Destroy(gameObject, _bulletDuration);
    }

    private void Update()
    {
        transform.position = transform.position + _direction * (_bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<LifeController>(out var life))
        {
            life.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    public void SetupBullet(Vector3 direction) => _direction = direction;

}
