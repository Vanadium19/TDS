using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IPlayerHealth
{
    public event Action PlayerDied;

    public void Die()
    {
        PlayerDied?.Invoke();
    }
}