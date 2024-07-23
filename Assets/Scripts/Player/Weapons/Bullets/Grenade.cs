using System.Collections;
using Enemies;
using UnityEngine;

namespace Player.Weapons.Bullets
{
    internal class Grenade : Projectile
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _explosionRadius = 2f;

        private Camera _camera;

        private void OnEnable()
        {
            if (_camera == null)
                _camera = Camera.main;
        }

        public override void Hurl(Transform startPoint)
        {
            transform.position = startPoint.position;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hitInfo);
            StartCoroutine(Move(new Vector3(hitInfo.point.x, 0, hitInfo.point.z)));
        }

        private IEnumerator Move(Vector3 destination)
        {
            var transform = this.transform;
            var delay = new WaitForFixedUpdate();
            var direction = destination - transform.position;

            while (transform.position.y > destination.y)
            {
                Body.MovePosition(transform.position + direction * Speed * Time.fixedDeltaTime);
                yield return delay;
            }

            Explode();
        }

        private void Explode()
        {
            var colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out IDamageable enemy))
                {
                    enemy.TakeDamage(_damage);
                }
            }

            Push();
        }
    }
}