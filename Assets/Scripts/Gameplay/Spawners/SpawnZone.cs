using UnityEngine;
using Utils;

namespace Gameplay.Spawners
{
    internal class SpawnZone : MonoBehaviour
    {
        private readonly float _behindScreenFactor = 1f;

        [SerializeField] private Transform _cornerPoint;

        private Camera _camera;
        private Transform _transform;

        private void Awake()
        {
            _camera = Camera.main;
            _transform = transform;
        }

        public Vector3 GetBehindScreenPoint()
        {
            Vector3 point = GetRandomPointInZone();

            return ClampPoint(point);
        }

        public Vector3 GetRandomPointInZone()
        {
            Vector3 point = _transform.position;

            point += Vector3.right * Random.Range(-_cornerPoint.localPosition.x, _cornerPoint.localPosition.x);
            point += Vector3.forward * Random.Range(-_cornerPoint.localPosition.z, _cornerPoint.localPosition.z);

            return point;
        }

        private Vector3 ClampPoint(Vector3 point)
        {
            Vector3 maxScreenPoint = _camera.ViewportToWorldPoint(Vector3.right + Vector3.up);
            Vector3 minScreenPoint = _camera.ViewportToWorldPoint(Vector3.zero);

            bool needClamp = point.x.IsBetween(
                minScreenPoint.x - _behindScreenFactor,
                maxScreenPoint.x + _behindScreenFactor);

            needClamp = needClamp && point.z.IsBetween(
                minScreenPoint.z - _behindScreenFactor,
                maxScreenPoint.z + _behindScreenFactor);

            if (needClamp)
            {
                point.x = maxScreenPoint.x >= _cornerPoint.localPosition.x ?
                    minScreenPoint.x - _behindScreenFactor :
                    maxScreenPoint.x + _behindScreenFactor;
            }

            return point;
        }
    }
}