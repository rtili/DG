using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHandler : MonoBehaviour, IBonusPickUp
{
    public void TakeBonus(IBonus bonus)
    {
        bonus.BonusAbility(gameObject);
    }
}
