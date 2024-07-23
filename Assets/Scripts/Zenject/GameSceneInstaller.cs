using Gameplay;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private MoveInput _moveInput;
    [SerializeField] private GunChanger _gunChanger;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private TimeController _timeController;

    public override void InstallBindings()
    {
        Container.Bind<IMoveInput>().FromInstance(_moveInput);        
        Container.Bind<IGunChanger>().FromInstance(_gunChanger);
        Container.Bind<IScoreCounter>().FromInstance(_scoreCounter);
        Container.Bind<IPlayerHealth>().FromInstance(_player);
        Container.Bind<ITimeController>().FromInstance(_timeController);
    }
}