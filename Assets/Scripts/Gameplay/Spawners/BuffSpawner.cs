using Gameplay.Bonuses;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Spawners
{
    internal class BuffSpawner : BonusSpawner
    {
        [SerializeField] private List<Bonus> _bonuses;

        protected override void SpawnBonus(Vector3 position)
        {
            var bonus = _bonuses[Random.Range(0, _bonuses.Count)];

            bonus.gameObject.SetActive(true);
            bonus.transform.position = position;
        }
    }
}