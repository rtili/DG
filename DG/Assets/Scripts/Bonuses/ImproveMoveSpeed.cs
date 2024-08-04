using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImproveMoveSpeed : MonoBehaviour, IBonus
{
    [SerializeField] private float _bonusDuration;
    [SerializeField] private float _speedPercentage;
    public void BonusAbility(GameObject target)
    {
        target.TryGetComponent<IMovementSpeedAffect>(out var move);
        move.AffectOnSpeed(_speedPercentage);
        StartCoroutine(BonusExpired(target));
    }

    public IEnumerator BonusExpired(GameObject target)
    {
        yield return new WaitForSeconds(_bonusDuration);
        target.TryGetComponent<IMovementSpeedAffect>(out var move);
        move.AffectOnSpeed(1 / _speedPercentage);
        Destroy(gameObject);
    }
}