using System;
using Battle;
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

        private GameObject _gameObject;

        public void Init()
        {
            _gameObject = gameObject;

            SetRadius(_stats.Values[0]);
        }

        public void Activate() => _gameObject.SetActive(true);
        public void DeActivate() => _gameObject.SetActive(false);

        private void SetRadius(float radius) //метод сделан на будущее, чтобы можно было увеличивать радиус атаки
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