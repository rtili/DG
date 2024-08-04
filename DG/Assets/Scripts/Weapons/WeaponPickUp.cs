using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IWeaponPickUp>(out var pickup))
        {
            if (gameObject.TryGetComponent<Weapon>(out var weapon))
            {
                pickup.Weapon = weapon;
                pickup.TakeWeapon();
            }
        }
    }
}
