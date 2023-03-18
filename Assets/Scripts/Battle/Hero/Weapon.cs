using UnityEngine;

namespace Battle.Hero
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Stats _shootIntervalStats;
        [SerializeField] private Stats _strengthStats;

        private int _currentShootingIntervalLevel;
        private int _currentStrengthLevel;

        private float _shootInterval;
        private float _lastShootTime;

        private float _shootStrength;

        public void Init()
        {
            _shootInterval = _shootIntervalStats.Values[_currentShootingIntervalLevel];
            _shootStrength = _strengthStats.Values[_currentStrengthLevel];
        }

        public void Activate() => enabled = true;
        public void DeActivate() => enabled = false;

        public void UpgradeFrequency() => TryUpdate(ref _currentShootingIntervalLevel, ref _shootIntervalStats, ref _shootInterval);
        public void UpgradeStrength() => TryUpdate(ref _currentStrengthLevel, ref _strengthStats, ref _shootStrength);

        private void TryUpdate(ref int level, ref Stats stats, ref float value)
        {
            if (level == stats.Values.Count - 1)
            {
                Debug.LogError("некорректная попытка апгрейда!");
                return;
            }

            level++;
            value = stats.Values[level];
        }

        private void Update()
        {

        }
    }
}