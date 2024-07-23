using System;

public interface IScoreCounter
{
    public event Action<int> ScoreChanged;

    public void AddEnemy(IDamageable enemy);
}