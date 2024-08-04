using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invulnerable : MonoBehaviour, IBonus
{
    [SerializeField] private float _bonusDuration;

    public void BonusAbility(GameObject target)
    {
        target.TryGetComponent<IInvulnerable>(out var invul);
        invul.IsInvulnerable = true;
        StartCoroutine(BonusExpired(target));
    }

    public IEnumerator BonusExpired(GameObject target)
    {
        yield return new WaitForSeconds(_bonusDuration);
        target.TryGetComponent<IInvulnerable>(out var invul);
        invul.IsInvulnerable = false;
        Destroy(gameObject);
    }
}
