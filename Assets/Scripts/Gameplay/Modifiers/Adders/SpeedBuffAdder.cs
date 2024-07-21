using UnityEngine;

public class SpeedBuffAdder : BuffAdder
{
    protected override void AddBuff(GameObject player)
    {
        player.AddComponent<SpeedBuff>();
    }
}