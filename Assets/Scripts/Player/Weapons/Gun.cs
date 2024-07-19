using UnityEngine;

internal class Gun : MonoBehaviour, IGun
{
    [SerializeField] private float _delay;
    [SerializeField] private float _damage;
    [SerializeField] private Transform _startPoint;

    private float _delayCounter;

    private void Update()
    {
        if (_delayCounter >= 0)
            _delayCounter -= Time.deltaTime;
    }

    public void Shoot()
    {
        if (_delayCounter >= 0)
            return;

        if (Physics.Raycast(_startPoint.position, _startPoint.forward, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.TryGetComponent(out IDamageable enemy))
            {
                enemy.TakeDamage(_damage);
            }
        }

        _delayCounter = _delay;
    }
}