using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [Tooltip("IGun")]
    [SerializeField] private GameObject _weapon;

    private IGun _gun;

    private void OnValidate()
    {
        if (_weapon.TryGetComponent(out IGun gun))
            _gun = gun;
        else
            _weapon = null;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _gun.Shoot();
        }
    }
}