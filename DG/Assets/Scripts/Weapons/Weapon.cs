using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float BulletsPerSecond { get { return _bulletsPerSecond; } }
    [SerializeField] protected int _damage;
    [SerializeField] private float _bulletsPerSecond;
    [SerializeField] protected Transform _bulletSpawner;
    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected float _bulletShootForce;
    public abstract void Shoot();
}
