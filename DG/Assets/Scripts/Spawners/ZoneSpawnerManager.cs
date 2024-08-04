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
    /// ���������� �������� ���� ������ ���
    /// </summary>
    private void GenerateZones()
    {
        GenerateZone(_deathZonePrefab, _deathZoneCount, _deathZoneRadius);
        GenerateZone(_slowZonePrefab, _slowZoneCount, _slowZoneRadius);
    }

    /// <summary>
    /// ������� ����
    /// </summary>
    /// <param name="zonePrefab">������ ����</param>
    /// <param name="zoneCount">���������� ��� ��� ��������</param>
    /// <param name="radius">������ ����</param>
    private void GenerateZone(GameObject zonePrefab, int zoneCount, float radius)
    {
        for (int i = 0; i < zoneCount; i++)
        {
            // ��������� ����� � ������ ������� �� ����� � ������� ����
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
    /// �������� ��������� ���, ��� �� ����� �����, ��� � �� ������ ���(������ ������,
    /// �� ����� ����� ��������� ������, �� ��� �������)    
    /// </summary>
    /// <param name="position">��������������� �������</param>
    /// <param name="existingZonePositions">���� ���� �������</param>
    /// <param name="zoneRadius">������ ����������� ����</param>
    /// <returns>True - ������������ �������, False - ����������</returns>
    private bool CheckZoneDistance(Vector3 position, List<Vector3> existingZonePositions, float zoneRadius)
    {
        // �������� ��������� �� ����� �����
        if (position.x < -_mapWidth + _mapEdgeMargin + zoneRadius || position.x > _mapWidth - _mapEdgeMargin - zoneRadius ||
            position.z < -_mapLength + _mapEdgeMargin + zoneRadius || position.z > _mapLength - _mapEdgeMargin - zoneRadius)
        {
            return false;
        }
        // ���������� ������ �� ������
        if (Vector3.Distance(position, Vector3.zero) < _zonesMargin + zoneRadius * 2)
        {
            return false;
        }
        // �������� ��������� �� ���
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
