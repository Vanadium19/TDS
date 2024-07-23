using System;

public interface IPlayerHealth
{
    public event Action PlayerDied;

    public void Die();
}