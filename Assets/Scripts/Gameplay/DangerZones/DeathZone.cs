using Player;
using UnityEngine;

namespace Gameplay.DangerZones
{
    internal class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IPlayerHealth player))
                player.Die();
        }
    }
}