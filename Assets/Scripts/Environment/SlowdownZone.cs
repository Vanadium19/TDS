using UnityEngine;

public class SlowdownZone : MonoBehaviour
{
    private readonly float _percentFactor = 100f;

    [Range(0, 100)]
    [SerializeField] private int _slowdownPercent;

    private float _slowdownFactor;

    private void Start()
    {
        _slowdownFactor = _slowdownPercent / _percentFactor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ISpeedController speedController))
            speedController.MultiplySpeed(0.6f);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ISpeedController speedController))
            speedController.ResetSpeed();
    }
}