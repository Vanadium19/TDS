using System;
using Enemies;

namespace Gameplay
{
    public interface IScoreCounter
    {
        public event Action<int> ScoreChanged;

        public int Score { get; }

        public void AddEnemy(IDamageable enemy);
    }
}