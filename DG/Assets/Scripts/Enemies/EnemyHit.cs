using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IInvulnerable>(out var invul))
        {
            if (invul.IsInvulnerable == true)
            {
                return;
            }
            else
            {
                collision.gameObject.TryGetComponent<IDeath>(out var death);
                death.Dead();
            }
        }
    }
}
