using UnityEngine;

public class Bullet : Projectile
{
    [SerializeField] private float _damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out IDamageable enemy))
            enemy.TakeDamage(_damage);

        Push();
    }
}