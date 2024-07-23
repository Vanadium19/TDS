using UnityEngine;
using Zenject;

public class GameFinisher : MonoBehaviour
{
    [SerializeField] private GameOverView _gameOverView;

    [Inject]
    private IPlayerHealth _player;
    [Inject]
    private ITimeController _timeController;

    private void OnEnable()
    {
        _player.PlayerDied += OnPlayerDied;
    }

    private void OnDisable()
    {
        _player.PlayerDied -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        _timeController.StopGame();
        _gameOverView.gameObject.SetActive(true);
        _gameOverView.DisplayScore();
    }
}