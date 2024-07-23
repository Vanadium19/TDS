using System.Collections.Generic;
using System.Linq;
using Gameplay.Bonuses;
using Gameplay.Spawners;
using UnityEngine;
using Zenject;

internal class GunSpawner : BonusSpawner
{
    private readonly float _spawnAngleX = 90f;
    private readonly float _minSpawnAngleY = 0f;
    private readonly float _maxSpawnAngleY = 359f;
    private readonly float _spawnAngleZ = 0f;

    [SerializeField] private List<GunPackage> _gunPackages;

    [Inject]
    private IGunChanger gunChanger;

    protected override void SpawnBonus(Vector3 position)
    {
        var guns = _gunPackages.Where(gun => gun.Name != gunChanger.CurrentGun).ToList();

        var gun = guns[Random.Range(0, guns.Count)];

        gun.gameObject.SetActive(true);
        gun.transform.position = position;
        var spawnAngleY = Random.Range(_minSpawnAngleY, _maxSpawnAngleY);
        gun.transform.rotation = Quaternion.Euler(_spawnAngleX, spawnAngleY, _spawnAngleZ);
    }
}