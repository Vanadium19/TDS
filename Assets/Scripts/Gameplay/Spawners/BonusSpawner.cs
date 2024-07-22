using UnityEngine;

public abstract class BonusSpawner : MonoBehaviour
{
    private readonly float _spawnPositionZ = 10f;
    private readonly float _minCameraPosition = 0f;
    private readonly float _maxCameraPosition = 1f;

    [SerializeField] private float _delay = 10f;
    
    private Camera _camera;
    private float _delayCounter;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (_delayCounter > 0)
            _delayCounter -= Time.deltaTime;

        Spawn();
    }

    private void Spawn()
    {
        if (_delayCounter > 0)
            return;

        SpawnBonus(GetRandomPosition());

        _delayCounter = _delay;
    }

    protected abstract void SpawnBonus(Vector3 position);

    private Vector3 GetRandomPosition()
    {
        var screenPoint = new Vector3(
            Random.Range(_minCameraPosition, _maxCameraPosition),
            Random.Range(_minCameraPosition, _maxCameraPosition),
            _spawnPositionZ);

        return _camera.ViewportToWorldPoint(screenPoint);
    }
}