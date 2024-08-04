using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSpawnerManager : MonoBehaviour
{
    [SerializeField] private GameObject _deathZonePrefab, _slowZonePrefab;
    [SerializeField] private int _deathZoneCount, _slowZoneCount, _mapEdgeMargin, _zonesMargin;
    [SerializeField] private float _mapWidth, _mapLength, _deathZoneRadius, _slowZoneRadius;
    private List<Vector3> _allZonePositions = new List<Vector3>();

    private void Start()
    {
        GenerateZones();
    }

    /// <summary>
    /// Совмещение созданий всех нужных зон
    /// </summary>
    private void GenerateZones()
    {
        GenerateZone(_deathZonePrefab, _deathZoneCount, _deathZoneRadius);
        GenerateZone(_slowZonePrefab, _slowZoneCount, _slowZoneRadius);
    }

    /// <summary>
    /// Создать зону
    /// </summary>
    /// <param name="zonePrefab">Префаб зоны</param>
    /// <param name="zoneCount">Количество зон для создания</param>
    /// <param name="radius">Радиус зоны</param>
    private void GenerateZone(GameObject zonePrefab, int zoneCount, float radius)
    {
        for (int i = 0; i < zoneCount; i++)
        {
            // Генерация точек с учетом отступа от краев и радиуса зоны
            Vector3 position = new Vector3(
                Random.Range(-_mapWidth + _mapEdgeMargin + radius, _mapWidth - _mapEdgeMargin - radius),
                0,
                Random.Range(-_mapLength + _mapEdgeMargin + radius, _mapLength - _mapEdgeMargin - radius)
            );

            if (CheckZoneDistance(position, _allZonePositions, radius))
            {
                _allZonePositions.Add(position);
                Instantiate(zonePrefab, position, Quaternion.identity);
            }
            else
            {
                _allZonePositions.Remove(position);
                i--;
            }
        }
    }

    /// <summary>
    /// Проверка дистанции зон, как от краев карты, так и от других зон(Важный момент,
    /// от краев карты применяем радиус, от зон диаметр)    
    /// </summary>
    /// <param name="position">Сгенерированная позиция</param>
    /// <param name="existingZonePositions">Лист всех позиций</param>
    /// <param name="zoneRadius">Радиус итерируемой зоны</param>
    /// <returns>True - Регистрирует позицию, False - Пропускает</returns>
    private bool CheckZoneDistance(Vector3 position, List<Vector3> existingZonePositions, float zoneRadius)
    {
        // Проверка дистанции от краев карты
        if (position.x < -_mapWidth + _mapEdgeMargin + zoneRadius || position.x > _mapWidth - _mapEdgeMargin - zoneRadius ||
            position.z < -_mapLength + _mapEdgeMargin + zoneRadius || position.z > _mapLength - _mapEdgeMargin - zoneRadius)
        {
            return false;
        }
        // Исключение смерти на спавне
        if (Vector3.Distance(position, Vector3.zero) < _zonesMargin + zoneRadius * 2)
        {
            return false;
        }
        // Проверка дистанции от зон
        foreach (Vector3 existingZonePosition in existingZonePositions)
        {
            if (Vector3.Distance(position, existingZonePosition) < _zonesMargin + zoneRadius * 2)
            {
                return false;
            }
        }
        return true;
    }
}
