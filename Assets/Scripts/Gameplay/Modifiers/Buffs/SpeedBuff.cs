using UnityEngine;

[RequireComponent(typeof(ISpeedController))]
public class SpeedBuff : Buff
{
    private readonly float _speedUpFactor = 1.5f;

    private ISpeedController _speedController;

    private void Awake()
    {
        _speedController = GetComponent<ISpeedController>();
    }

    protected override void Add()
    {
        base.Add();
        _speedController.MultiplySpeed(_speedUpFactor);
    }

    protected override void Remove()
    {
        _speedController.ResetSpeed();
        base.Remove();
    }
}