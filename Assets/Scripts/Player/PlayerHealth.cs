using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IPlayerHealth
{
    private bool _isInvulnerable;

    public event Action PlayerDied;

    public void Die()
    {
        if (_isInvulnerable)
            return;

        PlayerDied?.Invoke();
    }

    public void SetInvulnerable(bool value)
    {
        _isInvulnerable = value;
    }
}