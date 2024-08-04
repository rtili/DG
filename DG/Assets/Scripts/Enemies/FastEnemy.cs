using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{
    void Update()
    {
        Move();
        TryEnemyDeath();
    }
}
