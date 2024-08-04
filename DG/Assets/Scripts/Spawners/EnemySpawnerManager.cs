using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawnerManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private float _mapWidth;
    [SerializeField] private float _mapHeight;
    [SerializeField] private float _startSpawnTime;
    [SerializeField] private float _timeToDecreaseSpawnTime;
    [SerializeField] private float _stepToDecreaseSpawnTime;
    [SerializeField] private float _minSpawnTime;
    private float _nextSpawnTime;
    private float _spawnTime;
    private float _timer;

    private void Start()
    {
        _spawnTime = _startSpawnTime;
        _timer = _timeToDecreaseSpawnTime;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        _nextSpawnTime -= Time.deltaTime;
        if (_nextSpawnTime <= 0)
        {
            SpawnEnemy();
            _nextSpawnTime = _spawnTime;
        }
        if (_timer <= 0)
        {
            if (_spawnTime > _minSpawnTime)
            {
                _spawnTime -= _stepToDecreaseSpawnTime;
            }
            else
            {
                return;
            }
            _timer = _timeToDecreaseSpawnTime;
        }
    }

    private void SpawnEnemy()
    {
        float random = Random.value;
        float chance;
        float currentChance = 0;
        for (int i = 0; i < _enemyPrefabs.Length; i++)
        {
            chance = _enemyPrefabs[i].GetComponent<Enemy>().SpawnChance;
            currentChance += chance;
            if (random <= currentChance)
            {
                Instantiate(_enemyPrefabs[i], SpawnOutsideCam(), Quaternion.identity);
                return;
            }
        }
        
    }

    /// <summary>
    /// Спавн вне камеры, в пределах погрешности 
    /// </summary>
    /// <returns>Вектор позиции не в области камеры</returns>
    private Vector3 SpawnOutsideCam()
    {
        Vector3 spawnPos;
        /// Определение видимости камеры
        Vector3[] angles = new Vector3[]
        {
            Camera.main.ViewportToWorldPoint(new Vector3(0, 0)),
            Camera.main.ViewportToWorldPoint(new Vector3(1, 0)),
            Camera.main.ViewportToWorldPoint(new Vector3(0, 1)),
            Camera.main.ViewportToWorldPoint(new Vector3(1, 1))
        };
        /// Получение рандомной точки
        spawnPos = new Vector3(Random.Range(-_mapWidth, _mapWidth), 1, Random.Range(-_mapHeight, _mapHeight));
        /// Сверка векторов точки и видимости камеры
        while (spawnPos.x >= angles[0].x && spawnPos.z >= angles[0].z &&
            spawnPos.x <= angles[1].x && spawnPos.z >= angles[1].z &&
            spawnPos.x >= angles[2].x && spawnPos.z <= angles[2].z &&
            spawnPos.x <= angles[3].x && spawnPos.z <= angles[3].z)
        {
            spawnPos = new Vector3(Random.Range(-_mapWidth, _mapWidth), 1, Random.Range(-_mapHeight, _mapHeight));
        }
        return spawnPos;
    }
}
