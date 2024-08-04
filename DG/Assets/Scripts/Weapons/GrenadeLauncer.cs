using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncer : Weapon
{
    public override void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane playerPlane = new(Vector3.up, transform.position);

        if (playerPlane.Raycast(ray, out float hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            GameObject grenade = Instantiate(_bullet, _bulletSpawner.position, Quaternion.identity);
            grenade.GetComponent<Rigidbody>().AddForce(transform.forward * _bulletShootForce, ForceMode.Impulse);
            grenade.GetComponent<Grenade>().GrenadeDamage = _damage;
            grenade.GetComponent<Grenade>().Target = targetPoint;
        }
    }
}
