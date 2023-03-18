using System;
using UnityEngine;
using Battle.Enemies;

namespace Battle
{
    public class Enemy : MonoBehaviour, IPoolable, IEnemy
    {
        public event Action Destroyed;
        public event Action<float> TakenDamage;

        [SerializeField] private EnemyVars _vars;

        public bool IsActive => _gameObject.activeSelf;
        public Vector3 Position => _vars.Transform.position;
        public bool IsDestroyed => _isDestroyed;

        private float _startHealth;
        [SerializeField] private bool _isDestroyed;
        
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

            if (_vars.Health < 0f)
            {
                Destroy();
            }
        }

        public void Destroy()
        {
            _stateMachine.ChangeState(new EnemyDieState(_vars, DeActivate));
            _isDestroyed = true;
            Destroyed?.Invoke();
        }

        private void ChangeDefaultState() => _stateMachine.ChangeState(new EnemyDefaultState(_vars));

        private void FixedUpdate() => _stateMachine.FixedTick();

        private void OnDisable()
        {
            _isDestroyed = false;
            
            _vars.Health = _startHealth;
            _vars.RootTransform.gameObject.SetActive(true);
        }

        private void Awake()
        {
            _gameObject = gameObject;
            _vars.Transform = transform;
            _startHealth = _vars.Health;
        }
    }
}