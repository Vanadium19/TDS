using UnityEngine;
using Zenject;

namespace Player.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    internal class PlayerMover : MonoBehaviour, ISpeedController
    {
        [SerializeField] private float _speed;

        [Inject]
        private IMoveInput _moveInput;
        private Rigidbody _rigidbody;
        private float _currentSpeed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            ResetSpeed();
        }

        private void Update()
        {
            _rigidbody.velocity = Vector3.up * _rigidbody.velocity.y + _currentSpeed * _moveInput.Value;
        }

        public void MultiplySpeed(float value)
        {
            _currentSpeed *= value;
        }

        public void ResetSpeed()
        {
            _currentSpeed = _speed;
        }
    }
}