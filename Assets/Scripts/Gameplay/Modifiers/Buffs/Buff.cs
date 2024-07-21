using UnityEngine;

public abstract class Buff : MonoBehaviour
{
    private readonly float _duration = 10f;

    private float _durationCounter;

    private void Start()
    {
        Add();
    }

    private void Update()
    {
        if (_durationCounter > 0)
        {
            _durationCounter -= Time.deltaTime;
            return;
        }

        Remove();
    }

    protected virtual void Add()
    {
        _durationCounter = _duration;
    }

    protected virtual void Remove()
    {
        Destroy(this);
    }
}