using Player.Weapons;

namespace Player
{
    public interface IGunChanger
    {
        public GunName CurrentGun { get; }

        public void ChangeGun(GunName gun);
    }
}