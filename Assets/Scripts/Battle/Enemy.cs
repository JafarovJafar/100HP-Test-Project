using System;
using UnityEngine;
using Battle.Enemies;

namespace Battle
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        public event Action<IDestroyable> Destroyed;
        public event Action<float> TakenDamage;

        [SerializeField] private EnemyVars _vars;
        [SerializeField] private float _cost = 1f;

        public bool IsActive => _gameObject.activeSelf;
        public Vector3 Position => _vars.Transform.position;
        public bool IsDestroyed => _isDestroyed;
        public float Cost => _cost;

        private float _startHealth;
        private bool _isDestroyed;
        
        private StateMachine _stateMachine = new StateMachine();
        
        private GameObject _gameObject;

        public void Activate()
        {
            _gameObject.SetActive(true);
            ChangeDefaultState();
        }

        public void DeActivate()
        {
            _gameObject.SetActive(false);
        }

        public void SetParent(Transform parent) => _vars.Transform.parent = parent;
        public void SetPosition(Vector3 position) => _vars.Transform.position = position;
        public void SetRotation(Quaternion rotation) => _vars.Transform.rotation = rotation;
        public void SetTarget(IHero hero) => _vars.Hero = hero;

        public void TakeDamage(float damage)
        {
            _vars.Health -= damage;

            if (_vars.Health <= 0f)
            {
                Destroy();
            }
            else
            {
                TakenDamage?.Invoke(damage);
            }
        }

        public void Destroy()
        {
            if (_isDestroyed) return;
            
            _stateMachine.ChangeState(new EnemyDieState(_vars, DeActivate));
            _isDestroyed = true;
            Destroyed?.Invoke(this);
        }

        private void ChangeDefaultState() => _stateMachine.ChangeState(new EnemyDefaultState(_vars));

        private void FixedUpdate() => _stateMachine.FixedTick();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out IHero hero))
            {
                _vars.CanAttackHero = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out IHero hero))
            {
                _vars.CanAttackHero = false;
            }
        }

        private void OnDisable()
        {
            _isDestroyed = false;
            
            _vars.Health = _startHealth;
            _vars.RootTransform.gameObject.SetActive(true);
            _vars.CanAttackHero = false;
        }

        private void Awake()
        {
            _gameObject = gameObject;
            _vars.Transform = transform;
            _startHealth = _vars.Health;
        }
    }
}