using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out IPlayerHealth player))
            player.Die();
    }
}