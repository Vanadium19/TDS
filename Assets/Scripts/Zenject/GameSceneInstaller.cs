using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private MoveInput _moveInput;
    [SerializeField] private GunChanger _gunChanger;

    public override void InstallBindings()
    {
        Container.Bind<IMoveInput>().FromInstance(_moveInput);        
        Container.Bind<IGunChanger>().FromInstance(_gunChanger);
    }
}