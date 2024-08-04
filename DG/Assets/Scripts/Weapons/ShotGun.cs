using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
    [SerializeField] private int _projectileCount;
    [SerializeField] private float _spreadAngle;
    [SerializeField] private float _bulletMaxDistance;

    public override void Shoot()
    {
        float halfSectorAngle = _spreadAngle / 2f;
        for (int i = 0; i < _projectileCount; i++)
        {
            float angle = -halfSectorAngle + i / (_projectileCount - 1f) * _spreadAngle;
            Vector3 forceDirection = Quaternion.Euler(0, angle, 0) * transform.forward;
            GameObject bullet = Instantiate(_bullet, _bulletSpawner.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(forceDirection * _bulletShootForce, ForceMode.Impulse);
            bullet.GetComponent<Bullet>().BulletDamage = _damage;
            bullet.GetComponent<Bullet>().MaxBulletDistance = _bulletMaxDistance;
        }
    }
}
