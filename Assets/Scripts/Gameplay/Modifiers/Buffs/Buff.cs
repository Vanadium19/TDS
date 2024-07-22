using UnityEngine;

public abstract class Buff : MonoBehaviour
{
    private readonly float _duration = 10f;

    private void OnEnable()
    {
        Add();
    }

    protected virtual void Add()
    {
        Invoke(nameof(Remove), _duration);
    }

    protected virtual void Remove()
    {
        enabled = false;
    }
}