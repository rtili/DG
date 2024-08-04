using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredEnemy : Enemy
{
    void Update()
    {
        Move();
        TryEnemyDeath();
    }
}
