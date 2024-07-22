using UnityEngine;

public class DangerZoneSpawner : MonoBehaviour
{
    private readonly float _minDistance = 3f;

    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private SpawnZone _spawnZone;
    [SerializeField] private SphereCollider _dangerZone;
    [SerializeField] private int _count;

    private void Start()
    {
        Spawn();
    }
  
    private void Spawn()
    {
        for (int i = 0; i < _count; i++)
        {
            Vector3 position = Vector3.zero;
            var colliders = new Collider[_count];

            while (colliders.Length != 0)
            {
                position = _spawnZone.GetRandomPointInZone();

                colliders = Physics.OverlapSphere(position, _dangerZone.radius + _minDistance, _layerMask);
            }

            Instantiate(_dangerZone, position, Quaternion.identity);
        }
    }
}