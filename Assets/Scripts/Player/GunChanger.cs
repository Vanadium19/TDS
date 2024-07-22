using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAttacker))]
public class GunChanger : MonoBehaviour
{
    [Tooltip("0 - Pistol, 1 - Shotgun, 2 - Kalashnikov, 3 - GrenadeLauncher")]
    [SerializeField] private List<Gun> _guns;

    private PlayerAttacker _playerAttacker;

    private void Awake()
    {
        _playerAttacker = GetComponent<PlayerAttacker>();
    }

    private void Start()
    {
        ChangeGun(WeaponName.Pistol);
    }

    public void ChangeGun(WeaponName name)
    {
        for (int i = 0; i < _guns.Count; i++)
            _guns[i].gameObject.SetActive(i == (int)name);

        _playerAttacker.ChangeGun(_guns[(int)name]);
    }
}