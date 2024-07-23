using UnityEngine;

namespace Enemies.Configs
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies/Create new Enemy", order = 51)]
    internal class EnemyParameters : ScriptableObject
    {
        [Range(0, 100)]
        [SerializeField] private int _spawnChance;
        [SerializeField] private int _score;
        [SerializeField] private float _health;
        [SerializeField] private float _speed;

        public int SpawnChance => _spawnChance;
        public int Score => _score;
        public float Health => _health;
        public float Speed => _speed;
    }
}