using UnityEngine;

internal class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health;
    [SerializeField] private int _rewardPoints;

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
        Destroy(gameObject);        
    }
}