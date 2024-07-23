using System.Linq;
using Enemies;
using Enemies.Configs;
using UnityEngine;

namespace Gameplay.Spawners
{
    internal class EnemiesPool : MonoBehaviour
    {
        private readonly int _minPercent = 1;
        private readonly int _maxPercent = 100;

        [SerializeField] private Enemy[] _enemies;

        private void Awake()
        {
            if (_enemies.Sum(enemy => enemy.SpawnChance) != _maxPercent)
                throw new System.ArgumentOutOfRangeException(nameof(EnemyParameters.SpawnChance));

            _enemies = _enemies.OrderBy(enemy => enemy.SpawnChance).ToArray();
        }

        public Enemy GetRandomEnemy()
        {
            int currentChance = 0;
            int result = Random.Range(_minPercent, _maxPercent);

            foreach (var enemy in _enemies)
            {
                currentChance += enemy.SpawnChance;

                if (result <= currentChance)
                    return enemy;

            }

            return null;
        }
    }
}