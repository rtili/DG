using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IBonusPickUp>(out var pickup))
        {
            if (gameObject.TryGetComponent<IBonus>(out var bonus))
            {
                pickup.TakeBonus(bonus);
                gameObject.transform.position = new Vector3(0, -10);
            }
        }
    }
}
