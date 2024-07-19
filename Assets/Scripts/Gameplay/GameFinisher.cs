using UnityEngine;

public class GameFinisher : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private GameObject _gameOverPanel;

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
        _gameOverPanel.SetActive(true);
    }
}