using UnityEngine;

namespace Gameplay
{
    internal class TimeController : MonoBehaviour, ITimeController
    {
        private readonly float _pauseTimeScale = 0f;
        private readonly float _playTimeScale = 1f;

        public void ContinueGame()
        {
            Time.timeScale = _playTimeScale;
        }

        public void StopGame()
        {
            Time.timeScale = _pauseTimeScale;
        }
    }
}