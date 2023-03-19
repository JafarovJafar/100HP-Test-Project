using System.Collections;
using UnityEngine;

namespace Battle.Hero
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Stats _shootIntervalStats;
        [SerializeField] private Stats _strengthStats;
        [SerializeField] private Projectile _projectilePrefab;

        public Stats IntervalStats => _shootIntervalStats;
        public Stats StrengthStats => _strengthStats;
        public bool IsReloading => _isReloading;
        public int CurrentIntervalLevel => _currentShootingIntervalLevel;
        public int CurrentStrengthLevel => _currentStrengthLevel;

        private int _currentShootingIntervalLevel;
        private int _currentStrengthLevel;

        private float _shootInterval;
        private float _lastShootTime;

        private float _shootStrength;

        private WaitForSeconds _reloadWFS;
        private bool _isReloading;

        private Transform _transform;

        public void Init()
        {
            _transform = transform;

            _shootInterval = _shootIntervalStats.Values[_currentShootingIntervalLevel].Value;
            _shootStrength = _strengthStats.Values[_currentStrengthLevel].Value;

            _reloadWFS = new WaitForSeconds(_shootInterval);
        }

        public void Activate() => enabled = true;
        public void DeActivate() => enabled = false;

        public void ShootAt(IEnemy enemy)
        {
            Vector3 position = _transform.position;
            Vector3 direction = enemy.Position - position;
            direction.Normalize();
            Quaternion rotation = Quaternion.FromToRotation(Vector2.up, direction);

            Projectile projectile = MonoPool.Instance.Get(_projectilePrefab);
            projectile.SetStrength(_shootStrength);
            projectile.SetPosition(position);
            projectile.SetRotation(rotation);

            _isReloading = true;
            StartCoroutine(ReloadCoroutine());
        }

        public void UpgradeFrequency()
        {
            if (TryUpdate(ref _currentShootingIntervalLevel, ref _shootIntervalStats, ref _shootInterval))
            {
                _reloadWFS = new WaitForSeconds(_shootInterval);
            }
        }

        public void UpgradeStrength() => TryUpdate(ref _currentStrengthLevel, ref _strengthStats, ref _shootStrength);

        private bool TryUpdate(ref int level, ref Stats stats, ref float value)
        {
            if (level == stats.Values.Count - 1)
            {
                Debug.LogError("некорректная попытка апгрейда!");
                return false;
            }

            level++;
            value = stats.Values[level].Value;
            return true;
        }

        private IEnumerator ReloadCoroutine()
        {
            yield return _reloadWFS;
            _isReloading = false;
        }
    }
}