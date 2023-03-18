using UnityEngine;

namespace Battle.Hero
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Stats _frequencyStats;
        [SerializeField] private Stats _strengthStats;

        private int _level;
        private float _speedInterval;
        private float _lastShootTime;

        public void Init()
        {
        }

        public void DeActivate()
        {
        }

        public void Activate()
        {
        }

        private void Update()
        {

        }
    }
}