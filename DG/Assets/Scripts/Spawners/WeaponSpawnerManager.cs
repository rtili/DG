using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawnerManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _weaponPrefabs;
    [SerializeField] private float _spawnMaxTime;
    [SerializeField] private float _spawnHoldMaxTime;
    [SerializeField] private Shooting _shooting;
    private float _spawnTimer;
    private int _currentWeaponIndex;
    private GameObject _spawnedWeapon;

    private void Start()
    {
        SpawnWeapon();
    }

    private void Update()
    {
        _spawnTimer += Time.deltaTime;
        TrySpawnWeapon();
        TryDestroyWeapon();
    }

    /// <summary>
    /// Спавн оружия
    /// </summary>
    private void TrySpawnWeapon()
    {
        if (_spawnTimer >= _spawnMaxTime)
        {
            if (_shooting.Weapon == null)
                SpawnWeapon();
            else
                SpawnAnotherWeapon();
            _spawnTimer = 0f;
        }
    }

    /// <summary>
    /// Удаление бесхозного оружия
    /// </summary>
    private void TryDestroyWeapon()
    {
        if (_spawnTimer >= _spawnHoldMaxTime && _spawnedWeapon != null)
        {
            if (_shooting.Weapon != null && _spawnedWeapon.name != _shooting.Weapon.gameObject.name)            
                Destroy(_spawnedWeapon);            
            if (_shooting.Weapon == null)            
                Destroy(_spawnedWeapon);            
            else            
                return;            
        }
    }

    /// <summary>
    /// Создание оружия отличного от имеющегося у игрока
    /// </summary>
    private void SpawnAnotherWeapon()
    {
        SpawnWeapon();
        while (_spawnedWeapon.name == _shooting.Weapon.gameObject.name)
        {
            Destroy(_spawnedWeapon);
            SpawnWeapon();
            if (_spawnedWeapon.name != _shooting.Weapon.gameObject.name)            
                break;            
        }
    }

    /// <summary>
    /// Создание любого оружия на карте в области камеры
    /// </summary>
    private void SpawnWeapon()
    {
        Vector3 spawnPoint = GetRandomPointInView();
        _currentWeaponIndex = Random.Range(0, _weaponPrefabs.Length);
        GameObject weapon = Instantiate(_weaponPrefabs[_currentWeaponIndex], spawnPoint, Quaternion.identity);
        _spawnedWeapon = weapon;
    }

    /// <summary>
    /// Рандомная точка в области видимости камеры
    /// </summary>
    /// <returns>Вектор точки в области камеры</returns>
    private Vector3 GetRandomPointInView()
    {
        Camera mainCamera = Camera.main;
        Vector3 viewportPoint = new Vector3(Random.value, Random.value, mainCamera.nearClipPlane);
        Vector3 worldPoint = mainCamera.ViewportToWorldPoint(viewportPoint);
        worldPoint.y = 0.5f;
        return worldPoint;
    }
}
