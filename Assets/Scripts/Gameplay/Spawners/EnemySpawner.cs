using UnityEngine;
using Zenject;

namespace Gameplay.Spawners
{
    [RequireComponent(typeof(EnemiesPool))]
    internal class EnemySpawner : MonoBehaviour
    {
        private readonly float _minDelay = 0.5f;

        [SerializeField] private Transform _player;
        [SerializeField] private SpawnZone _spawnZone;
        [SerializeField] private float _delay = 2f;

        [Inject]
        private IScoreCounter _scoreCounter;
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

            CreateEnemy(position);

            _delayCounter = _delay;
        }

        private void CreateEnemy(Vector3 position)
        {
            var enemy = Instantiate(_pool.GetRandomEnemy(), position, Quaternion.identity);

            enemy.Initialize(_player);
            _scoreCounter.AddEnemy(enemy);
        }
    }
}