using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : MonoBehaviour
{
    [SerializeField] private float _speedPercentage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IMovementSpeedAffect>(out var move))        
            move.AffectOnSpeed(_speedPercentage);       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IMovementSpeedAffect>(out var move))
            move.AffectOnSpeed(1 / _speedPercentage);
    }
}
