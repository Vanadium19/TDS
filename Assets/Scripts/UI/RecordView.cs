using Gameplay;
using TMPro;
using UnityEngine;

namespace UI
{
    internal class RecordView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _recordScore;

        private void Start()
        {
            _recordScore.text = $"Record: {GameSaver.Score}";
        }
    }
}