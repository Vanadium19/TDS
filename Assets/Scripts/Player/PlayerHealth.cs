using System;
using UnityEngine;

namespace Player
{
    internal class PlayerHealth : MonoBehaviour, IPlayerHealth
    {
        private bool _isInvulnerable;

        public event Action PlayerDied;

        public void Die()
        {
            if (_isInvulnerable)
                return;

            gameObject.SetActive(false);
            PlayerDied?.Invoke();
        }

        public void SetInvulnerable(bool value)
        {
            _isInvulnerable = value;
        }
    }
}