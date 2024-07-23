using UnityEngine;

namespace Gameplay.Spawners
{
    [RequireComponent(typeof(EnemySpawner))]
    internal class SpawnerDelaySubstracter : MonoBehaviour
    {
        [SerializeField] private float _subtrahendValue = 0.1f;
        [SerializeField] private float _delay = 10f;

        private EnemySpawner _spawner;
        private float _delayCounter;

        private void Awake()
        {
            _spawner = GetComponent<EnemySpawner>();
        }

        private void Start()
        {
            _delayCounter = _delay;
        }

        private void Update()
        {
            if (_delayCounter > 0)
            {
                _delayCounter -= Time.deltaTime;
                return;
            }

            _spawner.SubstractDelay(_subtrahendValue);
            _delayCounter = _delay;
        }
    }
}