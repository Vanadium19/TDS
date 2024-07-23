using System;

namespace Player
{
    public interface IPlayerHealth
    {
        public event Action PlayerDied;

        public void Die();
    }
}