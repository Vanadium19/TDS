using UnityEngine;

[RequireComponent(typeof(EnemiesPool))]
public class EnemySpawner : MonoBehaviour
{    
    private readonly float _minDelay = 0.5f;

    [SerializeField] private Transform _player;
    [SerializeField] private SpawnZone _spawnZone;
    [SerializeField] private float _delay = 2f;

    private EnemiesPool _pool;
    private float _delayCounter;

    private void Awake()
    {
        _pool = GetComponent<EnemiesPool>();
    }

    private void Update()
    {
        if (_delayCounter > 0)
        {
            _delayCounter -= Time.deltaTime;
            return;
        }

        Spawn();
    }

    public void SubstractDelay(float value)
    {
        if (value <= 0 || _delay <= _minDelay)
            return;

        _delay -= value;
    }

    private void Spawn()
    {
        Vector3 position = _spawnZone.GetBehindScreenPoint();

        Instantiate(_pool.GetRandomEnemy(), position, Quaternion.identity).Initialize(_player);

        _delayCounter = _delay;
    }  
}