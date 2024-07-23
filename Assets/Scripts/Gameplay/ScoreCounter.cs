using Enemies;
using System;
using UnityEngine;
using Zenject;

public class ScoreCounter : MonoBehaviour, IScoreCounter
{
    [Inject]
    private IPlayerHealth _player;

    public event Action<int> ScoreChanged;

    private int _score;

    public int Score => _score;

    private void OnEnable()
    {
        _player.PlayerDied += OnPlayerDied;
    }

    private void Start()
    {
        ScoreChanged?.Invoke(_score);
    }

    private void OnDisable()
    {
        _player.PlayerDied -= OnPlayerDied;
    }

    public void AddEnemy(IDamageable enemy)
    {
        enemy.EnemyDied += OnEnemyDied;
    }

    private void OnEnemyDied(IDamageable enemy, int score)
    {
        _score += score;
        ScoreChanged?.Invoke(_score);
        enemy.EnemyDied -= OnEnemyDied;
    }

    private void OnPlayerDied()
    {
        if (GameSaver.Score < _score)
            GameSaver.SaveScore(_score);
    }
}