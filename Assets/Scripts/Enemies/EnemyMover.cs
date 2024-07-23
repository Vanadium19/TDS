using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody))]
    internal class EnemyMover : MonoBehaviour
    {
        private float _speed;
        private Transform _target;
        private Transform _transform;
        private Rigidbody _rigidbody;
        private Vector3 _direction;

        private void Awake()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _direction = Vector3.ProjectOnPlane(_target.position - _transform.position, Vector3.up).normalized;

            _rigidbody.velocity = _direction * _speed + Vector3.up * _rigidbody.velocity.y;
            _transform.LookAt(_target);
        }

        public void Initialize(Transform target, float speed)
        {
            _target = target;
            _speed = speed;
        }
    }
}