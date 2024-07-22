using UnityEngine;

public class SpeedBonus : Bonus
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SpeedBuff buff))
        {
            buff.enabled = true;
            gameObject.SetActive(false);
        }
    }
}