using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int BulletDamage { set{ _bulletDamage = value; } }
    public float MaxBulletDistance { set { _maxBulletDistance = value; } }
    [SerializeField] private float _bulletLife;
    private int _bulletDamage;
    private float _maxBulletDistance;
    private Vector3 _startPos;

    private void Start()
    {
        _startPos = transform.position;
        Destroy(gameObject, _bulletLife);
    }

    private void Update()
    {
        if (_maxBulletDistance != 0)
        {
            if (Vector3.Distance(_startPos, transform.position) >= _maxBulletDistance)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out var damage))
        {
            damage.TakeDamage(_bulletDamage);
        }
        Destroy(gameObject);
    }
}
