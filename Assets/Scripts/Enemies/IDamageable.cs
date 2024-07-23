using System;

namespace Enemies
{
    public interface IDamageable
    {
        public event Action<IDamageable, int> EnemyDied;

        public void TakeDamage(float value);
    }
}