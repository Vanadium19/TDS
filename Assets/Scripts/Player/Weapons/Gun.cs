using UnityEngine;

[RequireComponent(typeof(ProjectilesPool))]
internal class Gun : MonoBehaviour, IGun
{
    [SerializeField] private float _delay;
    [SerializeField] private Transform _startPoint;    

    private ProjectilesPool _pool;
    private float _delayCounter;

    protected Transform StartPoint => _startPoint;

    private void Awake()
    {
        _pool = GetComponent<ProjectilesPool>();
    }

    private void Update()
    {
        if (_delayCounter >= 0)
            _delayCounter -= Time.deltaTime;
    }

    public void Shoot()
    {
        if (_delayCounter >= 0)
            return;

        PutBullet();

        _delayCounter = _delay;
    }

    protected virtual void PutBullet()
    {
        var bullet = _pool.Pull();
        bullet.gameObject.SetActive(true);
        bullet.Hurl(_startPoint);
    }
}