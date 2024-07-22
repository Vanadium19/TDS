using System.Collections.Generic;
using UnityEngine;

public class BuffSpawner : BonusSpawner
{
    [SerializeField] private List<Bonus> _bonuses;

    protected override void SpawnBonus(Vector3 position)
    {
        var bonus = _bonuses[Random.Range(0, _bonuses.Count)];

        bonus.gameObject.SetActive(true);
        bonus.transform.position = position;
    }
}