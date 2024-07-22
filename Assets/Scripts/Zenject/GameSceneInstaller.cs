using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private MoveInput _moveInput;

    public override void InstallBindings()
    {
        Container.Bind<IMoveInput>().FromInstance(_moveInput);
    }
}