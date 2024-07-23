using System.Collections.Generic;
using Player.Weapons;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerAttacker))]
    internal class GunChanger : MonoBehaviour, IGunChanger
    {
        [Tooltip("0 - Pistol, 1 - Shotgun, 2 - Kalashnikov, 3 - GrenadeLauncher")]
        [SerializeField] private List<Gun> _guns;

        private GunName _currentGun;
        private PlayerAttacker _playerAttacker;

        public GunName CurrentGun => _currentGun;

        private void Awake()
        {
            _playerAttacker = GetComponent<PlayerAttacker>();
        }

        private void Start()
        {
            ChangeGun(GunName.Pistol);
        }

        public void ChangeGun(GunName gun)
        {
            for (int i = 0; i < _guns.Count; i++)
                _guns[i].gameObject.SetActive(i == (int)gun);

            _playerAttacker.ChangeGun(_guns[(int)gun]);
            _currentGun = gun;
        }
    }
}