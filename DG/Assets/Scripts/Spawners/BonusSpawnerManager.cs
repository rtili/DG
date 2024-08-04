using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawnerManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _bonusPrefabs;
    [SerializeField] private float _spawnMaxTime;
    [SerializeField] private float _spawnHoldMaxTime;
    private float _spawnTimer;
    private int _currentBonusIndex;
    private GameObject _spawnedBonus;
    private Vector3 _spawnPos;

    private void Start()
    {
        SpawnBonus();
    }

    private void Update()
    {
        _spawnTimer += Time.deltaTime;
        TrySpawnBonus();
        TryDestroyBonus();
    }

    /// <summary>
    /// ����� ������
    /// </summary>
    private void TrySpawnBonus()
    {
        if (_spawnTimer >= _spawnMaxTime)
        {
            SpawnBonus();
            _spawnTimer = 0f;
        }
    }

    /// <summary>
    /// �������� ���������� ������
    /// </summary>
    private void TryDestroyBonus()
    {
        if (_spawnTimer >= _spawnHoldMaxTime && _spawnedBonus != null)
        {
            if (Vector3.Distance(_spawnedBonus.transform.position, _spawnPos) < 0.5f)
                Destroy(_spawnedBonus);
            else
                return;
            _spawnTimer = 0f;
        }
    }

    /// <summary>
    /// �������� ������ ������ �� ����� � ������� ������
    /// </summary>
    private void SpawnBonus()
    {
        Vector3 spawnPoint = GetRandomPointInView();
        _currentBonusIndex = Random.Range(0, _bonusPrefabs.Length);
        GameObject bonus = Instantiate(_bonusPrefabs[_currentBonusIndex], spawnPoint, Quaternion.identity);
        _spawnedBonus = bonus;
    }

    /// <summary>
    /// ��������� ����� � ������� ��������� ������
    /// </summary>
    /// <returns>������ ����� � ������� ������</returns>
    private Vector3 GetRandomPointInView()
    {
        Camera mainCamera = Camera.main;
        Vector3 viewportPoint = new Vector3(Random.value, Random.value, mainCamera.nearClipPlane);
        Vector3 worldPoint = mainCamera.ViewportToWorldPoint(viewportPoint);
        worldPoint.y = 0.5f;
        _spawnPos = worldPoint;
        return worldPoint;
    }
}
