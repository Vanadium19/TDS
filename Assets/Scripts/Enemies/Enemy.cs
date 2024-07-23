using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyParameters _enemyParameters;
    
    private float _health;
    private EnemyMover _mover;

    public event Action<IDamageable, int> EnemyDied;

    public int SpawnChance => _enemyParameters.SpawnChance;

    private void Awake()
    {        
        _mover = GetComponent<EnemyMover>();
    }    

    public void Initialize(Transform target)
    {
        _health = _enemyParameters.Health;
        _mover.Initialize(target, _enemyParameters.Speed);
    }

    public void TakeDamage(float value)
    {
        if (value <= 0)
            return;

        _health -= value;

        if (_health <= 0)
        {
            _health = 0;
            Die();
        }
    }

    private void Die()
    {
        EnemyDied?.Invoke(this, _enemyParameters.Score);
        Destroy(gameObject);
    }
}