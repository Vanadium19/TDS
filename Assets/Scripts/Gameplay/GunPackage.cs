using UnityEngine;

public class GunPackage : Bonus
{
    [SerializeField] private GunName _gunName;

    public GunName Name => _gunName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IGunChanger gunChanger))
        {
            gunChanger.ChangeGun(_gunName);
            gameObject.SetActive(false);
        }
    }
}