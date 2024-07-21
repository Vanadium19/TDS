using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private MoveInput _moveInput;
    [SerializeField] private Gun _defaultGun;

    public override void InstallBindings()
    {
        Container.Bind<IMoveInput>().FromInstance(_moveInput);
        Container.Bind<IGun>().FromInstance(_defaultGun);
    }
}