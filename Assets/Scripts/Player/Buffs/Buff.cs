using UnityEngine;

namespace Player.Buffs
{
    internal abstract class Buff : MonoBehaviour
    {
        private readonly float _duration = 10f;

        private float _durationCounter;

        private void OnEnable()
        {
            Add();
        }

        private void Update()
        {
            if (_durationCounter > 0)
            {
                _durationCounter -= Time.deltaTime;
                return;
            }

            Remove();
        }

        public void ResetTime()
        {
            _durationCounter = _duration;
        }

        protected virtual void Add()
        {
            ResetTime();
        }

        protected virtual void Remove()
        {
            enabled = false;
        }
    }
}