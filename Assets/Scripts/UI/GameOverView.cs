using Gameplay;
using TMPro;
using UnityEngine;
using Zenject;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private GameObject _newRecordTitle;
    [SerializeField] private TMP_Text _scoreText;

    [Inject]
    private IScoreCounter _scoreCounter;

    public void DisplayScore()
    {
        _scoreText.text = _scoreCounter.Score.ToString();

        if (_scoreCounter.Score > GameSaver.Score)
            _newRecordTitle.SetActive(true);
    }

    [ContextMenu("Reset")]
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}