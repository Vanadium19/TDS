using UnityEngine;

public abstract class BuffAdder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IPlayerHealth player))
        {
            AddBuff(other.gameObject);
            Destroy(gameObject);
        }
    }

    protected abstract void AddBuff(GameObject player);
}