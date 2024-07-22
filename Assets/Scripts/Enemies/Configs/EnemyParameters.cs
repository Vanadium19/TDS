using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies/Create new Enemy", order = 51)]
public class EnemyParameters : ScriptableObject
{
    [Range(0, 100)]
    [SerializeField] private int _spawnChance;
    [SerializeField] private int _rewardPoint;
    [SerializeField] private float _health;
    [SerializeField] private float _speed;

    public int SpawnChance => _spawnChance;
    public int RewardPoint => _rewardPoint;
    public float Health => _health;
    public float Speed => _speed;
}