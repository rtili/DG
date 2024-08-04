using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СommonEnemy : Enemy
{
    void Update()
    {
        Move();
        TryEnemyDeath();
    }
}
