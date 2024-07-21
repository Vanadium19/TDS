using UnityEngine;
using Zenject;

public class PlayerAttacker : MonoBehaviour
{
    [Inject]
    private IGun _defaultGun;
    private IGun _currentGun;

    private void Start()
    {
        _currentGun = _defaultGun;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentGun.Shoot();
        }
    }
}