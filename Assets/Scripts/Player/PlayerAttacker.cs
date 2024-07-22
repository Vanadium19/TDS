using UnityEngine;
using Zenject;

public class PlayerAttacker : MonoBehaviour
{
    private IGun _currentGun;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentGun.Shoot();
        }
    }

    public void ChangeGun(IGun gun)
    {
        _currentGun = gun;
    }
}