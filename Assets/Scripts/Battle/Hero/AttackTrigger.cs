using System;
using UnityEngine;

namespace Battle.Hero
{
    public class AttackTrigger : MonoBehaviour
    {
        public event Action<Enemy> Entered;

        [SerializeField] private Stats _stats;
        [SerializeField] private CircleCollider2D _collider;
        [SerializeField] private Transform _spriteTransform;
        [SerializeField] private float _radius;

        private int _currentLevel;

        private GameObject _gameObject;

        public void Init()
        {
            _gameObject = gameObject;

            SetRadius(_stats.Values[0]);
        }

        public void Activate() => _gameObject.SetActive(true);
        public void DeActivate() => _gameObject.SetActive(false);

        public void Upgrade()
        {
            if (_currentLevel == _stats.Values.Count - 1)
            {
                Debug.LogError("некорректная попытка апгрейда!");
                return;
            }

            _currentLevel++;
            SetRadius(_stats.Values[_currentLevel]);
        }

        private void SetRadius(float radius)
        {
            _collider.radius = radius;
            _spriteTransform.localScale = Vector2.one * radius * 2f;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Enemy enemy)) Entered?.Invoke(enemy);
            else Debug.Log("этой коллизии не должно быть");
        }
    }
}