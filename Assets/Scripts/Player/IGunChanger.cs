using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGunChanger
{
    public GunName CurrentGun { get; }

    public void ChangeGun(GunName gun);
}