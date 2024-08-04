using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable, IGiveScore
{
    public float SpawnChance { get { return _spawnChance; } }
    [SerializeField]
    private int _enemyHealth, _scoreCost, _enemySpeed;
    [SerializeField] private float _spawnChance;
    private Transform _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    public void TakeDamage(int damage)
    {
        _enemyHealth -= damage;
    }

    public void GiveScore()
    {
        _player.gameObject.GetComponent<ISetScore>().GetScore(_scoreCost);
    }

    protected void TryEnemyDeath()
    {
        if (_enemyHealth <= 0)
        {
            Destroy(gameObject);
            GiveScore();
        }
    }

    protected void Move()
    {
        Vector3 direction = _player.position - transform.position;
        direction.Normalize();
        transform.position += _enemySpeed * Time.deltaTime * direction;
    }    
}
