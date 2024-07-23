using Player;
using UnityEngine;

namespace Enemies
{
    internal class EnemyAttacker : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out IPlayerHealth player))
                player.Die();
        }
    }
}