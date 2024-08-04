using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    public override void Shoot()
    {
        GameObject bullet = Instantiate(_bullet, _bulletSpawner.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().BulletDamage = _damage;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * _bulletShootForce, ForceMode.Impulse);
    }
}
