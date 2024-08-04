using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponPickUp
{
    public Weapon Weapon { set; }
    public void TakeWeapon();
}
