using UnityEngine;

public class ShotgunBullet : Bullet
{
    [SerializeField] private float _range = 7f;

    private float _delay;
    private float _timeCounter;

    private void Start()
    {
        _timeCounter = _delay = _range / Speed;
    }

    private void Update()
    {
        if (_timeCounter > 0)
        {
            _timeCounter -= Time.deltaTime;
            return;
        }

        Push();
    }

    public override void Hurl(Transform startPoint)
    {
        _timeCounter = _delay;
        base.Hurl(startPoint);
    }
}