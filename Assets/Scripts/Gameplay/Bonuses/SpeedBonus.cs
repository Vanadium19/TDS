using Player.Buffs;
using UnityEngine;

namespace Gameplay.Bonuses
{
    internal class SpeedBonus : Bonus
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out SpeedBuff buff))
            {
                if (buff.enabled)
                    buff.ResetTime();
                else
                    buff.enabled = true;

                gameObject.SetActive(false);
            }
        }
    }
}