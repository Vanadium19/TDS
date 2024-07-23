using UnityEngine;

namespace Gameplay.Bonuses
{
    internal class Bonus : MonoBehaviour
    {
        [SerializeField] private float _delay = 5f;

        private float _delayCounter;

        private void OnEnable()
        {
            _delayCounter = _delay;
        }

        private void Update()
        {
            if (_delayCounter > 0)
            {
                _delayCounter -= Time.deltaTime;
                return;
            }

            gameObject.SetActive(false);
        }
    }
}