using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour, IWeaponPickUp
{
    public Weapon Weapon { get { return _weapon; } set { _weapon = value; } }
    private Weapon _weapon;
    [SerializeField] private Transform _weaponPos;
    private float _fireRate;

    private void Update()
    {
        if (Input.GetMouseButton(0))
            if (_weapon != null)
            {
                if (_fireRate <= 0)
                {
                    _fireRate = (1 / _weapon.BulletsPerSecond);
                    _weapon.Shoot();
                }
                else
                {
                    print("Перезарядка");
                }
            }
            else
            {
                print("Нет оружия");
            }
        if (_fireRate > 0)
            _fireRate -= Time.deltaTime;
    }

    public void TakeWeapon()
    {
        _weapon.GetComponent<BoxCollider>().enabled = false;
        if (_weaponPos.childCount > 0)
        {
            Destroy(_weaponPos.GetChild(0).gameObject);
        }
        _weapon.transform.SetParent(_weaponPos);
        _weapon.transform.localPosition = Vector3.zero;
        _weapon.transform.localRotation = Quaternion.identity;
    }
}
