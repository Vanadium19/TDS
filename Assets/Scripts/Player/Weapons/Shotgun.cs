using UnityEngine;

namespace Player.Weapons
{
    internal class Shotgun : Gun
    {
        private readonly float _radiusFactor = 2f;

        [SerializeField] private int _bulletCount = 5;
        [SerializeField] private float _shootAngle = 10f;
        [SerializeField] private float _angularStep = 2.5f;

        private Quaternion _step;
        private Quaternion _startAngle;

        private void Start()
        {

            _step = Quaternion.Euler(0, _angularStep, 0);
            _startAngle = Quaternion.Euler(0, -Mathf.Abs(_shootAngle / _angularStep), 0);
        }

        protected override void PutBullet()
        {
            StartPoint.localRotation = _startAngle;

            for (int i = 0; i < _bulletCount; i++)
            {
                StartPoint.localRotation = StartPoint.localRotation * _step;
                base.PutBullet();
            }
        }
    }
}