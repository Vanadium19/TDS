using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    
    private ProjectilesPool _pool;
    private Transform _transform;
    private Rigidbody _rigidbody;

    protected float Speed => _speed;
    protected Rigidbody Body => _rigidbody;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(ProjectilesPool pool)
    {
        _pool = pool;
    }

    public virtual void Hurl(Transform startPoint)
    {
        _transform.position = startPoint.position;
        _transform.rotation = startPoint.rotation;
        _rigidbody.velocity = startPoint.forward * _speed;
    }

    protected void ApplyDamage(IDamageable enemy)
    {
        enemy.TakeDamage(_damage);
    }

    protected void Push()
    {
        _pool.Push(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out IDamageable enemy))
            ApplyDamage(enemy);

        Push();
    }
}