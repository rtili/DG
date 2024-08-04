using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBonus 
{
    public void BonusAbility(GameObject target);
    public IEnumerator BonusExpired(GameObject target);
}
