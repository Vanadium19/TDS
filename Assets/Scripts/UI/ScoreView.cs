using TMPro;
using UnityEngine;
using Zenject;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    [Inject]
    private IScoreCounter _scoreCounter;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _scoreText.text = score.ToString();
    }
}