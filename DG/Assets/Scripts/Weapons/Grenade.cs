using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public int GrenadeDamage { set { _grenadeDamage = value; } }
    public Vector3 Target { set{ _target = value; } }
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _grenadeLife;
    private Vector3 _target;
    private int _grenadeDamage;   

    private void Start()
    {
        Destroy(gameObject, _grenadeLife);
    }

    private void Update()
    {
        if (_target != null)
        {
            SetDestination();
        }
    }

    private void SetDestination()
    {
        if (Vector3.Distance(transform.position, _target) < 0.5f)
        {
            Explode();
        }
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(_grenadeDamage);
            }
        }
        Destroy(gameObject);
    }  
}
